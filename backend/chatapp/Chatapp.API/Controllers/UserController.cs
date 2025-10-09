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
                return BadRequest("User data is null");
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
            var returnUserDTO = _mapper.Map<ReturnUserDTO>(user);


            return Ok(returnUserDTO);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO LoginDTO)
        {
            if (LoginDTO is null)
            {
                return BadRequest("User data is null");
            }

            var user = await _unitOfWork.UserRepository.GetUserByEmailAndPasswordAsync(LoginDTO);

            if (user is null)
            {
                return BadRequest("UserName or Password Is Not Valid");
            }
            var returnUserDTO = _mapper.Map<ReturnUserDTO>(user);

            return Ok(returnUserDTO);
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var usersDTO = _mapper.Map<IEnumerable<ReturnUserDTO>>(users);
            return Ok(usersDTO);
        }
    }
}
