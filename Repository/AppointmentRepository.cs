using MedicalCenter.Context;
using MedicalCenter.Interfaces;
using MedicalCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Repository
{
    public class AppointmentRepository: IAppointmentRepository
    {
        private readonly MedicalContext _context;

        public AppointmentRepository(MedicalContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }

        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            return appointment;
        }

        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }

        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
