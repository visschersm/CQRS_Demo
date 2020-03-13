using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

// https://dejanstojanovic.net/aspnet/2019/may/automatic-cqrs-handler-registration-in-aspnet-core-with-reflection/

namespace Api
{
    public static class ServiceExtensions
    {
        public static void AddCommandQueryHandlers(this IServiceCollection services, Type handlerInterface)
        {
            var handlers = typeof(ServiceExtensions).Assembly.GetTypes()
        .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface)
    );

            foreach (var handler in handlers)
            {
                var interf = handler.GetInterfaces();
                var temp2 = interf.Where(x => x.IsGenericType);
                var temp3 = temp2.Where(x => x.GetGenericTypeDefinition() == handlerInterface);
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface), handler);
            }
        }
    }
}
