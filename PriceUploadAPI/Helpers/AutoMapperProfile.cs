using AutoMapper;
using PriceUploadAPI.Entities;
using PriceUploadAPI.ViewModels.Users;

namespace PriceUploadAPI.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}
