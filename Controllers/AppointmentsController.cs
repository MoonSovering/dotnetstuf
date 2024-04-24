using Microsoft.AspNetCore.Mvc;
using MedicalCenter.Models;
using MedicalCenter.Services;

namespace MedicalCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentsController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult> GetAppointments()
        {
            var appointments = await _appointmentService.GetAppointments();
            return Ok(appointments);
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointment(id);
            if (appointment.Value == null)
            {
                return NotFound();
            }
            return Ok(appointment.Value);
        }

        // PUT: api/Appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentID)
            {
                return BadRequest();
            }

            var result = await _appointmentService.PutAppointment(id, appointment);
            return result;
        }

        // POST: api/Appointments
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            var createdAppointment = await _appointmentService.PostAppointment(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = createdAppointment.Value.AppointmentID }, createdAppointment.Value);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var result = await _appointmentService.DeleteAppointment(id);
            return result;
        }
    }
}