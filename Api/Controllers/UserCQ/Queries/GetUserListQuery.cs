using Api.Interfaces;
using Api.Model;
using Api.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Api.Controllers.UserCQ.Queries
{
    public class GetUserListQuery : IRequest
    {
        internal class GetUserListQueryHandler : IQueryHandler<GetUserListQuery, UserListView>
        {
            private readonly UserDbContext _context;
            private readonly IMapper _mapper;

            public GetUserListQueryHandler(UserDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserListView> HandleAsync(GetUserListQuery command)
            {
                var result = await _context.Users.AsNoTracking()
                    .ProjectTo<UserLookupView>(_mapper.ConfigurationProvider)
                    .ToArrayAsync();

                return new UserListView
                {
                    Users = result
                };
            }
        }
    }
}
