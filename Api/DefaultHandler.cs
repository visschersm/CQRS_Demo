using Api.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Api
{
    public class DefaultHandler : IHandler
    {
        private readonly IServiceProvider _serviceProvider;

        public DefaultHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> HandleQueryAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest
        {
            var handler = _serviceProvider.GetService<IQueryHandler<TRequest, TResponse>>();

            if (!((handler != null) && handler is IQueryHandler<TRequest, TResponse>))
            {
                //throw new CommandHandlerNotFoundException(typeof(TCommand));
                throw new NotImplementedException();
            }

            return await handler.HandleAsync(request);

        }
        public async Task<IRequestResult> HandleCommandAsync<TRequest>(TRequest request) where TRequest : IRequest
        {
            var handler = _serviceProvider.GetService<ICommandHandler<TRequest>>();
            if (!((handler != null) && handler is ICommandHandler<TRequest>))
            {
                //throw new ValidationHandlerNotFoundException(typeof(TRequest));
                throw new NotImplementedException();
            }
            return await handler.HandleAsync(request);
        }
    }
}
