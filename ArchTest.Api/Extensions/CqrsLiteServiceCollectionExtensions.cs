﻿using ArchTest.Domain.Handlers;
using ArchTest.Domain.Rules;
using CQRSlite.Commands;
using CQRSlite.Messages;
using CQRSlite.Queries;
using CQRSlite.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace ArchTest.Api.Extensions
{
    public static class CqrsLiteServiceCollectionExtensions
    {
        public static IServiceCollection AddCqrsLite(this IServiceCollection services)
        {
            services.AddSingleton<Router>(new Router());
            services.AddSingleton<ICommandSender>(y => y.GetService<Router>());
            services.AddSingleton<IHandlerRegistrar>(y => y.GetService<Router>());

            services.Scan(scan => scan
                .FromAssemblies(typeof(InkoopOrderCommandHandler).GetTypeInfo().Assembly)
                    .AddClasses(classes => classes.Where(x =>
                    {
                        var allInterfaces = x.GetInterfaces();
                        return
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IHandler<>)) ||
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICancellableHandler<>)) ||
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IQueryHandler<,>)) ||
                            allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICancellableQueryHandler<,>));
                    }))
                    .AsSelf()
                    .WithTransientLifetime()
            );

            services.Scan(scan => scan
                .FromAssemblies(typeof(IRule).GetTypeInfo().Assembly)
                    .AddClasses(classes => classes.AssignableTo<IRule>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
            );

            return services;
        }
    }
}
