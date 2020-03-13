using Api.Controllers.UserCQ.CommandResults;
using Api.Interfaces;
using Api.Model;
using Api.Model.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.UserCQ.Commands
{
    public class CreateUserCommand : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
        {
            private readonly UserDbContext _context;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(UserDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IRequestResult> HandleAsync(CreateUserCommand command)
            {
                var exists = await _context.Users.AsNoTracking()
                    .Where(x =>
                        string.Compare(x.Username, command.UserName, true) == 0
                        || string.Compare(x.Email, command.Email, true) == 0)
                    .AnyAsync();

                if (exists)
                    return new UserAlreadyExistsResult();

                var result = _context.Users.Add(_mapper.Map<User>(command)).Entity;

                return new UserSuccessfullyCreatedResult();
            }
        }
    }
}
