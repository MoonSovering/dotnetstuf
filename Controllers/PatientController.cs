
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalCenter.Models;
using MedicalCenter.interfaces;

namespace MedicalCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _repository;

        public PatientController(IPatientRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var result = await _repository.GetPatients();

            if (!result.Any())
            {
                return NotFound(new { message = "No patient found in the patient list." });
            }

            return result.ToList();
        }

        // GET: api/Patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            try
            {
                var patient = await _repository.GetPatient(id);
                return patient;
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Patient not found." });
            }
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.PatientID)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdatePatient(patient);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Patient not found." });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            try
            {
                var createdPatient = await _repository.AddPatient(patient);
                return CreatedAtAction("GetPatient", new { id = createdPatient.PatientID }, createdPatient);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new { message = "Patient cannot be null." });
            }
        }

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                await _repository.DeletePatient(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Patient not found." });
            }
        }
    }
}
