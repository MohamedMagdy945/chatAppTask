using AutoMapper;
using Chatapp.Core.DTO;
using Chatapp.Core.Entities;
using Chatapp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chatapp.API.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IUnitOfWork unOfWork, IMapper mapper) : base(unOfWork , mapper)
        {
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            if (userDTO is null) {
                return BadRequest("User data is null.");
            }

            if (await _unitOfWork.UserRepository.EmailExistsAsync(userDTO.Email))
            {
                return BadRequest("Email already exists.");
            }

            var ImageUrl = string.Empty;
            try
            {
                if (userDTO.ProfileImage != null && userDTO.ProfileImage.Length > 0)
                {
                    ImageUrl = await _unitOfWork.ImageManagmentService.AddImageAsync(userDTO.ProfileImage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Image upload failed: {ex.Message}");
            }


            var user = _mapper.Map<User>(userDTO);
            user.ProfileImagePath = ImageUrl;
            await _unitOfWork.UserRepository.AddAsync(user);
            
            return Ok("user created successfully");
        }
    }
}
