using MedicalCenter.Models;
using Microsoft.AspNetCore.Mvc;

public interface IDoctorRepository
{
    Task<ActionResult<IEnumerable<Doctor>>> GetDoctors();
    Task<ActionResult<Doctor>> GetDoctor(int id);
    Task<IActionResult> PutDoctor(int id, Doctor doctor);
    Task<ActionResult<Doctor>> PostDoctor(Doctor doctor);
    Task<IActionResult> DeleteDoctor(int id);
}
