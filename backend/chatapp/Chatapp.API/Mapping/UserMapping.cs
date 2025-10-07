using AutoMapper;
using Chatapp.Core.DTO;
using Chatapp.Core.Entities;

namespace Chatapp.API.Mapping
{
    public class UserMapping: Profile
    {
        public UserMapping()
        {
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
