using MedicalCenter.Interfaces;
using MedicalCenter.Models;
using MedicalCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenter.Services
{
    public class AppointmentService: IAppointmentRepository
    {
        private readonly AppointmentRepository _appointmentRepository;

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointments = await _appointmentRepository.GetAppointments();

            if (!appointments.Value.Any())
            {
                throw new KeyNotFoundException("No Appointments found in the appointment list.");
            }

            return appointments;
        }

        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAppointment(id);

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

            var existingAppointment = await _appointmentRepository.GetAppointment(appointment.AppointmentID);
            if (existingAppointment.Value == null)
            {
                throw new KeyNotFoundException("Appointment not found.");
            }

            return await _appointmentRepository.PutAppointment(id, appointment);
        }

        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }

            return await _appointmentRepository.PostAppointment(appointment);
        }

        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAppointment(id);
            if (appointment.Value == null)
            {
                throw new KeyNotFoundException("Appointment not found.");
            }

            return await _appointmentRepository.DeleteAppointment(id);
        }
    }
}
