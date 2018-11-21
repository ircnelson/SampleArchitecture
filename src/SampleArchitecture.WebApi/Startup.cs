using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SampleArchitecture.Application.Exceptions;
using SampleArchitecture.Application.Infrastructure;
using SampleArchitecture.Core.Exceptions;
using SampleArchitecture.Data.EFCore;
using SampleArchitecture.WebApi.Extensions;
using SampleArchitecture.WebApi.Infrastructure;
using StackExchange.Profiling.SqlFormatters;
using ApplicationLayerAssembly = SampleArchitecture.Application.AssemblyScan;
using ValidationException = SampleArchitecture.Application.Exceptions.ValidationException;

namespace SampleArchitecture.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ValidatorOptions.PropertyNameResolver = CamelCasePropertyNameResolver.ResolvePropertyName;
            
            var applicationLayerAssembly = typeof(ApplicationLayerAssembly).Assembly;
            
            services.AddOptions();
            services.AddMemoryCache();
            services.AddLocalization();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvcCore()
                .AddFormatterMappings()
                .AddJsonFormatters(settings =>
                {
                    settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    settings.DateParseHandling = DateParseHandling.DateTimeOffset;
                    settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                    settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    settings.Formatting = Formatting.Indented;
                    settings.Converters.Add(new StringEnumConverter());
                })
                .AddApiExplorer()
                .AddCors()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContextPool<ExampleContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("ExampleSqlite"));
                //options.UseSqlServer(Configuration.GetConnectionString("ExampleSqlServer"));
                //options.UseInMemoryDatabase(Guid.NewGuid().ToString());
            });
            
            services.AddOpenSpecificationApi(Configuration);

            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.SqlFormatter = new SqlServerFormatter();
                options.ShouldProfile = request =>
                    Configuration.GetSection("MiniProfiler").GetValue<bool?>("Enable") ?? true;
            }).AddEntityFramework();
            
            // Os Pipelines Behaviors são executados na respectiva ordem que são adicionados no Container.
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DurationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(applicationLayerAssembly);

            AssemblyScanner
                .FindValidatorsInAssembly(applicationLayerAssembly)
                .ForEach(e => services.AddTransient(e.InterfaceType, e.ValidatorType));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(context =>
                {
                    string InstanceId() => $"urn:backoffice:log:{Guid.NewGuid()}";

                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;
                    
                    if (exception is ValidationException validationException)
                    {
                        var problemDetails = new CustomValidationProblemDetails<ValidationError>
                        {
                            Status = StatusCodes.Status422UnprocessableEntity,
                            Instance = InstanceId(),
                            Details = validationException.Failures.Select(e => new ValidationError
                            {
                                Field = e.Key, Errors = e.Value
                            }).ToList()
                        };

                        context.Response.StatusCode = problemDetails.Status.GetValueOrDefault();
                        context.Response.WriteJson(problemDetails, "application/problem+json");
                    }
                    else if (exception is BusinessException backOfficeException)
                    {
                        var problemDetails = new CustomValidationProblemDetails<string>
                        {
                            Status = StatusCodes.Status422UnprocessableEntity,
                            Details = new [] { backOfficeException.Message },
                            Instance = InstanceId()
                        };
                        
                        context.Response.StatusCode = problemDetails.Status.GetValueOrDefault();
                        context.Response.WriteJson(problemDetails, "application/problem+json");
                    }
                    else if (exception is NotFoundException)
                    {
                        var problemDetails = new CustomValidationProblemDetails<string>
                        {
                            Status = StatusCodes.Status404NotFound,
                            Instance = InstanceId()
                        };
                        
                        context.Response.StatusCode = problemDetails.Status.GetValueOrDefault();
                        context.Response.WriteJson(problemDetails, "application/problem+json");
                    }
                    else
                    {
                        var errorDetail = Environment.IsDevelopment()
                            ? exception.Demystify().ToString()
                            : "The instance value should be used to identify the problem when calling customer support";

                        var problemDetails = new ProblemDetails
                        {
                            Title = "An unexpected error occurred!",
                            Status = StatusCodes.Status500InternalServerError,
                            Detail = errorDetail,
                            Instance = InstanceId()
                        };
                        
                        context.Response.StatusCode = problemDetails.Status.GetValueOrDefault();
                        context.Response.WriteJson(problemDetails, "application/problem+json");
                    }

                    // log the exception etc..

                    return Task.CompletedTask;
                });
            });

            app.UseMiniProfiler();

            app.UseRequestLocalization(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("pt-BR"),
                    new CultureInfo("en-US")
                };

                options.DefaultRequestCulture = new RequestCulture("pt-BR");
                // Formatting numbers, dates, etc.
                options.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                options.SupportedUICultures = supportedCultures;
            });
            
            app.UseMvc();
            app.UseOpenSpecificationApi();
            
        }
    }
}