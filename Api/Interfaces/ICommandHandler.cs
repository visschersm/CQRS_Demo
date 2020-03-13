using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface ICommandHandler<TRequest>
        where TRequest : IRequest
    {
        public Task<IRequestResult> HandleAsync(TRequest request);
    }
}
