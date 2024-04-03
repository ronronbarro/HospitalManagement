using HospitalManagement.API.Repository.Interfaces;
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
    }
}
