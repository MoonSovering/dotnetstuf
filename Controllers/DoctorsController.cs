using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCenter.Models;
using MedicalCenter.interfaces;

namespace MedicalCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _service;

        public DoctorsController(IDoctorRepository service)
        {
            _service = service;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            try
            {
                var doctors = await _service.GetDoctors();
                return doctors.Value.ToList();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "No Doctors found in the doctor list." });
            }
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            try
            {
                var doctor = await _service.GetDoctor(id);
                return doctor;
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Doctor cannot be found." });
            }
        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.DoctorID)
            {
                return BadRequest();
            }

            try
            {
                await _service.PutDoctor(id, doctor);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Doctor not found." });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            try
            {
                var createdDoctor = await _service.PostDoctor(doctor);
                return CreatedAtAction("GetDoctor", new { id = createdDoctor.Value.DoctorID }, createdDoctor);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { message = "Doctor cannot be null." });
            }
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            try
            {
                await _service.DeleteDoctor(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Doctor not found." });
            }
        }
    }
}