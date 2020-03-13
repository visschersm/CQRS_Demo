using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IQueryHandler<TRequest, TResponse>
    {
        public Task<TResponse> HandleAsync(TRequest request);
    }
}
