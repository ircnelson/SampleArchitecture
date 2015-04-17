// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace PJMT.Framework.DependencyInjection.Interfaces
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a sequence of <see cref="ServiceDescriptor"/> to the <paramref name="collection"/>.
        /// </summary>
        /// <param name="descriptors">The <see cref="IEnumerable{T}"/> of <see cref="ServiceDescriptor"/>s to add.</param>
        /// <returns>A reference to the current instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection Add(this IServiceCollection collection,
                                             IEnumerable<ServiceDescriptor> descriptors)
        {
            foreach (var descriptor in descriptors)
            {
                collection.Add(descriptor);
            }

            return collection;
        }

        /// <summary>
        /// Adds the specified <paramref name="descriptor"/> to the <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">The <see cref="IServiceCollection"/>.</param>
        /// <param name="descriptor">The <see cref="ServiceDescriptor"/>.</param>
        /// <returns>A reference to the current instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection Add(this IServiceCollection collection,
                                             ServiceDescriptor descriptor)
        {
            collection.Add(descriptor);
            return collection;
        }

        /// <summary>
        /// Adds the specified <paramref name="descriptor"/> to the <paramref name="collection"/> if the
        /// service type hasn't been already registered.
        /// </summary>
        /// <param name="collection">The <see cref="IServiceCollection"/>.</param>
        /// <param name="descriptor">The <see cref="ServiceDescriptor"/>.</param>
        /// <returns><c>true</c> if the <paramref name="descriptor"/> was added; otherwise <c>false</c>.</returns>
        public static bool TryAdd(this IServiceCollection collection,
                                  ServiceDescriptor descriptor)
        {
            if (!collection.Any(d => d.ServiceType == descriptor.ServiceType))
            {
                collection.Add(descriptor);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds the specified <paramref name="descriptors"/>s to the <paramref name="collection"/> if the
        /// service type hasn't been already registered.
        /// </summary>
        /// <param name="collection">The <see cref="IServiceCollection"/>.</param>
        /// <param name="descriptors">The <see cref="ServiceDescriptor"/>s.</param>
        /// <returns><c>true</c> if any of the <paramref name="descriptors"/>s was added; otherwise <c>false</c>.</returns>
        public static bool TryAdd(this IServiceCollection collection,
                                  IEnumerable<ServiceDescriptor> descriptors)
        {
            var anyAdded = false;
            foreach (var d in descriptors)
            {
                anyAdded = collection.TryAdd(d) || anyAdded;
            }

            return anyAdded;
        }

        public static IServiceCollection AddTransient(this IServiceCollection collection,
                                                      Type service,
                                                      Type implementationType)
        {
            return Add(collection, service, implementationType, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddTransient(this IServiceCollection collection,
                                                      Type service,
                                                      Func<IServiceProvider, object> implementationFactory)
        {
            return Add(collection, service, implementationFactory, ServiceLifetime.Transient);
        }

        public static IServiceCollection AddScoped(this IServiceCollection collection,
                                                   Type service,
                                                   Type implementationType)
        {
            return Add(collection, service, implementationType, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddScoped(this IServiceCollection collection,
                                                   Type service,
                                                   Func<IServiceProvider, object> implementationFactory)
        {
            return Add(collection, service, implementationFactory, ServiceLifetime.Scoped);
        }

        public static IServiceCollection AddSingleton(this IServiceCollection collection,
                                                      Type service,
                                                      Type implementationType)
        {
            return Add(collection, service, implementationType, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddSingleton(this IServiceCollection collection,
                                                      Type service,
                                                      Func<IServiceProvider, object> implementationFactory)
        {
            return Add(collection, service, implementationFactory, ServiceLifetime.Singleton);
        }

        public static IServiceCollection AddInstance(this IServiceCollection collection,
                                                     Type service,
                                                     object implementationInstance)
        {
            var serviceDescriptor = new ServiceDescriptor(service, implementationInstance);
            collection.Add(serviceDescriptor);
            return collection;
        }

        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services)
            where TImplementation : TService
        {
            return services.AddTransient(typeof(TService), typeof(TImplementation));
        }

        public static IServiceCollection AddTransient(this IServiceCollection services,
                                                      Type serviceType)
        {
            return services.AddTransient(serviceType, serviceType);
        }

        public static IServiceCollection AddTransient<TService>(this IServiceCollection services)
        {
            return services.AddTransient(typeof(TService));
        }

        public static IServiceCollection AddTransient<TService>(this IServiceCollection services,
                                                                Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            return services.AddTransient(typeof(TService), implementationFactory);
        }

        public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services)
            where TImplementation : TService
        {
            return services.AddScoped(typeof(TService), typeof(TImplementation));
        }

        public static IServiceCollection AddScoped(this IServiceCollection services,
                                                   Type serviceType)
        {
            return services.AddScoped(serviceType, serviceType);
        }

        public static IServiceCollection AddScoped<TService>(this IServiceCollection services,
                                                             Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            return services.AddScoped(typeof(TService), implementationFactory);
        }

        public static IServiceCollection AddScoped<TService>(this IServiceCollection services)
        {
            return services.AddScoped(typeof(TService));
        }

        public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services)
        {
            return services.AddSingleton(typeof(TService), typeof(TImplementation));
        }

        public static IServiceCollection AddSingleton(this IServiceCollection services,
                                                      Type serviceType)
        {
            return services.AddSingleton(serviceType, serviceType);
        }

        public static IServiceCollection AddSingleton<TService>(this IServiceCollection services)
        {
            return services.AddSingleton(typeof(TService));
        }

        public static IServiceCollection AddSingleton<TService>(this IServiceCollection services,
                                                                Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            return services.AddSingleton(typeof(TService), implementationFactory);
        }

        public static IServiceCollection AddInstance<TService>(this IServiceCollection services,
                                                               TService implementationInstance)
            where TService : class
        {
            return services.AddInstance(typeof(TService), implementationInstance);
        }

        /// <summary>
        /// Removes the first service in <see cref="IServiceCollection"/> with the same service type
        /// as <paramref name="descriptor"/> and adds <paramef name="descriptor"/> to the collection.
        /// </summary>
        /// <param name="collection">The <see cref="IServiceCollection"/>.</param>
        /// <param name="descriptor">The <see cref="ServiceDescriptor"/> to replace with.</param>
        /// <returns></returns>
        public static IServiceCollection Replace(this IServiceCollection collection,
                                                 ServiceDescriptor descriptor)
        {
            var registeredServiceDescriptor = collection.FirstOrDefault(s => s.ServiceType == descriptor.ServiceType);
            if (registeredServiceDescriptor != null)
            {
                collection.Remove(registeredServiceDescriptor);
            }

            collection.Add(descriptor);
            return collection;
        }

        private static IServiceCollection Add(IServiceCollection collection,
                                              Type service,
                                              Type implementationType,
                                              ServiceLifetime lifeCycle)
        {
            var descriptor = new ServiceDescriptor(service, implementationType, lifeCycle);
            collection.Add(descriptor);
            return collection;
        }

        private static IServiceCollection Add(IServiceCollection collection,
                                              Type service,
                                              Func<IServiceProvider, object> implementationFactory,
                                              ServiceLifetime lifeCycle)
        {
            var descriptor = new ServiceDescriptor(service, implementationFactory, lifeCycle);
            collection.Add(descriptor);
            return collection;
        }
    }
}
