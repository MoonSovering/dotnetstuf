using MedicalCenter.Context;
using MedicalCenter.interfaces;
using MedicalCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Services
{
    public class AppointmentService : IAppointmentRepository
    {
        private readonly MedicalContext _context;

        public AppointmentService(MedicalContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointments = await _context.Appointments.ToListAsync();

            if (!appointments.Any())
            {
                throw new KeyNotFoundException("No Appointments found in the appointment list.");
            }

            return appointments;
        }

        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                throw new KeyNotFoundException("Appointment not found.");
            }

            return appointment;
        }

        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }

            if (id != appointment.AppointmentID)
            {
                throw new ArgumentException("Appointment ID mismatch.");
            }

            if (!_context.Appointments.Any(e => e.AppointmentID == appointment.AppointmentID))
            {
                throw new KeyNotFoundException("Appointment not found.");
            }

            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }

        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                throw new KeyNotFoundException("Appointment not found.");
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
