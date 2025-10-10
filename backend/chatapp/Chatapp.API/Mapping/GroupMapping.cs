using AutoMapper;
using Chatapp.Core.DTO;
using Chatapp.Core.Entities;

namespace Chatapp.API.Mapping
{
    public class GroupMapping : Profile
    {
        public GroupMapping()
        {
            CreateMap<GroupDTO, Group>().ForMember(dest => dest.GroupImagePath, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<ReturnGroupDTO, Group>().ForMember(dest => dest.GroupImagePath, opt => opt.Ignore())
            .ReverseMap();
        }
    }
}
