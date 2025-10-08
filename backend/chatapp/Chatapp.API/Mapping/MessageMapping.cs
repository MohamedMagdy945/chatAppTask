using AutoMapper;
using Chatapp.Core.DTO;
using Chatapp.Core.Entities;

namespace Chatapp.API.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<MessageDTO, Message>().ForMember(dest => dest.FileUrl, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<Message, ReturnMessageDTO>().ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int) src.Type));
        }
    }
}
