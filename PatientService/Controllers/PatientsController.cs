using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientService.DTOs;
using PatientService.Models;
using PatientService.Service;

namespace PatientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientCreateDto dto)
        {
           List<PatientResponseDto> count = (List<PatientResponseDto>)await _service.GetAllPatients();

            //var url = await _service.UploadProfileImage(count.Count+1,file);

            var result = await _service.CreatePatient(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientResponseDto>> Get(int id)
        {
            var result = await _service.GetPatient(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientResponseDto>>> GetAll()
        {
            var result = await _service.GetAllPatients();
            return Ok(result);
        }
        [HttpGet("GetByEmail")]
        public async Task<ActionResult<PatientResponseDto>> GetByEmail(string email)
        {
            return await _service.GetByEmail(email);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PatientUpdateDto dto)
        {
            var result = await _service.UpdatePatient(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePatient(id);
            return NoContent();
        }

        [HttpGet("GetAuth")]
        public async Task<ActionResult<AuthResponseDto>> AuthValidate(string email, string PassHash)
        {
           var auth= await _service.AuthValidate(email, PassHash);
            return Ok(auth);
        }
        [HttpPost("upload-profile/{patientId}")]
        public async Task<IActionResult> UploadProfileImage(int patientId, IFormFile file)
        {
            var url = await _service.UploadProfileImage(patientId, file);
            return Ok(new { profileImageUrl = url });
        }

    }
}
