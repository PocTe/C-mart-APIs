using AutoMapper;
using C_mart_APIs.Model;

namespace C_mart_APIs.Profiles
{
    public class UserProfiles:Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserRequest>().ReverseMap(); 
        }
    }
}

