using MedicalCenter.Context;
using MedicalCenter.Interfaces;
using MedicalCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Repository
{
    public class SpecialityRepository: ISpecialityRepository
    {
        private readonly MedicalContext _context;

        public SpecialityRepository(MedicalContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Speciality>>> GetSpeciality()
        {
            var specialities = await _context.Speciality.ToListAsync();
            return specialities;
        }

        public async Task<ActionResult<Speciality>> GetSpeciality(int id)
        {
            var speciality = await _context.Speciality.FindAsync(id);
            return speciality;
        }

        public async Task<IActionResult> PutSpeciality(int id, Speciality speciality)
        {
            _context.Entry(speciality).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<ActionResult<Speciality>> PostSpeciality(Speciality speciality)
        {
            _context.Speciality.Add(speciality);
            await _context.SaveChangesAsync();
            return speciality;
        }

        public async Task<IActionResult> DeleteSpeciality(int id)
        {
            var speciality = await _context.Speciality.FindAsync(id);

            _context.Speciality.Remove(speciality);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
