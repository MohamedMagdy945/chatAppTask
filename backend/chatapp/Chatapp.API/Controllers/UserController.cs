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

            var user = _mapper.Map<User>(userDTO);
            await _unitOfWork.UserRepository.AddAsync(user);
            return Ok("user created successfully");
        }
    }
}
