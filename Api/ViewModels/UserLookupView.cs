using Api.Model.Entities;
using AutoMapper;

namespace Api.ViewModels
{
    public class UserLookupView : Profile, IView
    {
        public UserLookupView()
        {
            CreateMap<User, UserLookupView>();
        }
    }
}
