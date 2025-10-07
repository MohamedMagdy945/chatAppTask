using AutoMapper;
using Chatapp.Core.DTO;
using Chatapp.Core.Entities;
using Chatapp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chatapp.API.Controllers
{
    public class GroupController : BaseController
    {
        public GroupController(IUnitOfWork unOfWork, IMapper mapper) : base(unOfWork, mapper)
        {
        }
        [HttpPost("addgroup")]
        public async Task<IActionResult> AddGroup(GroupDTO groupDTO)
        {
            if (groupDTO is null)
            {
                return BadRequest("User data is null");
            }


            var ImageUrl = string.Empty;
            try
            {
                if (groupDTO.GroupImage != null && groupDTO.GroupImage.Length > 0)
                {
                    ImageUrl = await _unitOfWork.ImageManagmentService.AddImageAsync(groupDTO.GroupImage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Image upload failed: {ex.Message}");
            }


            var group = _mapper.Map<Group>(groupDTO);
            group.Members.Add(new GroupMember() { UserId = groupDTO.UserCreatedId , privateGroup = false});
            group.GroupImagePath = ImageUrl;
            await _unitOfWork.GroupRepository.AddAsync(group);

            return Ok("Group created successfully");
        }
        [HttpPost("subscribeToGroup")]
        public async Task<IActionResult> Subscribe(SubscribeGroupDTO groupDTO)
        {
            if (groupDTO is null)
            {
                return BadRequest("User data is null");
            }

            var group = await _unitOfWork.GroupRepository.GetByIdAsync(groupDTO.GroupId);

            if (group == null)
            {
                return NotFound("Group not found");
            }

            group.Members.Add(new GroupMember() { UserId = groupDTO.SubscribeUserId  });
            return Ok("Group created successfully");
        }
    }
}
