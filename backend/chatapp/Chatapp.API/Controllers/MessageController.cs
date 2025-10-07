using AutoMapper;
using Chatapp.Core.DTO;
using Chatapp.Core.Entities;
using Chatapp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chatapp.API.Controllers
{
    public class MessageController : BaseController
    {
        public MessageController(IUnitOfWork unOfWork, IMapper mapper) : base(unOfWork, mapper)
        {
        }
        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(MessageDTO MessageDTO)
        {

            if (MessageDTO.GroupId == null)
            {
                var group = new Group
                {
                    Name = "",
                    Members = new List<GroupMember>
                    {
                        new GroupMember { UserId = MessageDTO.SenderId },
                        new GroupMember { UserId = (int)MessageDTO.ReceiverId }
                    }
                };
                await _unitOfWork.GroupRepository.AddAsync(group);

                MessageDTO.GroupId = group.Id;
            }
            var message = _mapper.Map<Message>(MessageDTO);

            await _unitOfWork.MessageRepository.AddAsync(message);


            return Ok(new
            {
                message = "Message sent successfully",
                groupId = MessageDTO.GroupId
            });
        }
    }
}
