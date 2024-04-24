using MedicalCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenter.Interfaces
{
    public interface ISpecialityRepository
    {
        Task<ActionResult<IEnumerable<Speciality>>> GetSpeciality();
        Task<ActionResult<Speciality>> GetSpeciality(int id);
        Task<IActionResult> PutSpeciality(int id, Speciality speciality);
        Task<ActionResult<Speciality>> PostSpeciality(Speciality speciality);
        Task<IActionResult> DeleteSpeciality(int id);
    }
}
