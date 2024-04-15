using Microsoft.AspNetCore.Mvc;
using MedicalCenter.Models;
using MedicalCenter.interfaces;

namespace MedicalCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityRepository _specialityService;

        public SpecialityController(ISpecialityRepository specialityService)
        {
            _specialityService = specialityService;
        }

        // GET: api/Speciality
        [HttpGet]
        public async Task<ActionResult> GetSpecialities()
        {
            var specialities = await _specialityService.GetSpeciality();
            return Ok(specialities);
        }

        // GET: api/Speciality/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSpeciality(int id)
        {
            var speciality = await _specialityService.GetSpeciality(id);
            if (speciality.Value == null)
            {
                return NotFound();
            }
            return Ok(speciality.Value);
        }

        // PUT: api/Speciality/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeciality(int id, Speciality speciality)
        {
            if (id != speciality.SpecialityID)
            {
                return BadRequest();
            }

            var result = await _specialityService.PutSpeciality(id, speciality);
            return result;
        }

        // POST: api/Speciality
        [HttpPost]
        public async Task<ActionResult<Speciality>> PostSpeciality(Speciality speciality)
        {
            var createdSpeciality = await _specialityService.PostSpeciality(speciality);
            return CreatedAtAction(nameof(GetSpeciality), new { id = createdSpeciality.Value.SpecialityID }, createdSpeciality.Value);
        }

        // DELETE: api/Speciality/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpeciality(int id)
        {
            var result = await _specialityService.DeleteSpeciality(id);
            return result;
        }
    }
}