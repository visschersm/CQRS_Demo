using Api.Interfaces;
using System.Threading.Tasks;

namespace Api
{
    public interface IHandler
    {
        public Task<TResponse> HandleQueryAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest;
        public Task<IRequestResult> HandleCommandAsync<TRequest>(TRequest request) where TRequest : IRequest;
    }
}
