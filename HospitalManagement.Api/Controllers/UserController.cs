using HospitalManagement.API.Repository.Interfaces;
using HospitalManagement.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("user/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid || id == 0)
            {
                return BadRequest(ModelState);
            }

            var result = await _userRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("user/all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _userRepository.GetAllAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("user/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid || loginDto == null)
            {
                return BadRequest(ModelState);
            }

            var result = await _userRepository.LoginUserAsync(loginDto);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
