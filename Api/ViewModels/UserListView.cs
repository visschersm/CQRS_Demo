using Api.Model.Entities;
using AutoMapper;

namespace Api.ViewModels
{
    public class UserListView : Profile, IView
    {
        public UserLookupView[] Users { get; internal set; }

        public UserListView()
        {
            CreateMap<User, UserListView>();
        }
    }
}
