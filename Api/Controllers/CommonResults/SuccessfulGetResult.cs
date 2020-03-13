using Api.Interfaces;

namespace Api.Controllers.CommonResults
{
    public class SuccessfulGetResult<TType> : IRequestResult
    {
        public TType Data { get; set; }
    }
}
