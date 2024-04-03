using HospitalManagement.API.Repository.Interfaces;
using HospitalManagement.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{

    [ApiController]
    public class HospitalController : ControllerBase
    {

        private readonly IHospitalRepository _hospitalRepository;
        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        [Route("hospital/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var result = await _hospitalRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("hospital/all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _hospitalRepository.GetAllAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("hospital/add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Hospital hospital)
        {
            if (hospital == null)
            {
                return BadRequest("Hospital is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = await _hospitalRepository.Add(hospital);
            return Ok(item);
        }

    }
}
