using MedicalCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenter.interfaces
{
    public interface IAppointmentRepository
    {
        Task<ActionResult<IEnumerable<Appointment>>> GetAppointments();
        Task<ActionResult<Appointment>> GetAppointment(int id);
        Task<IActionResult> PutAppointment(int id, Appointment appointment);
        Task<ActionResult<Appointment>> PostAppointment(Appointment appointment);
        Task<IActionResult> DeleteAppointment(int id);
    }
}
