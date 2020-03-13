using Api.Interfaces;

namespace Api.Controllers.UserCQ.CommandResults
{
    public class UserSuccessfullyCreatedResult : IRequestResult
    {
        public int Id { get; set; }
    }
}
