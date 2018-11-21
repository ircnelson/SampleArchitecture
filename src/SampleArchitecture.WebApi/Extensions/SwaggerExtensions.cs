using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleArchitecture.WebApi.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddOpenSpecificationApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();

                var docCommentsFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, "xml");

                if (File.Exists(docCommentsFile))
                {
                    options.IncludeXmlComments(docCommentsFile);
                }

                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = configuration["App:Title"],
                    Version = configuration["App:Version"],
                    Description = configuration["App:Description"],
                    TermsOfService = configuration["App:TermsOfService"]
                });

                options.CustomSchemaIds(x => x.FullName);
            });
        }

        public static void UseOpenSpecificationApi(this IApplicationBuilder builder)
        {
            var configuration = builder.ApplicationServices.GetService<IConfiguration>();
            
            builder
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    var apiPath = configuration.GetValue<string>("ApiPath");
                    
                    c.SwaggerEndpoint($"{apiPath}/swagger/v1/swagger.json", "API V1");
                });
        }
    }
}