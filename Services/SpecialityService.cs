using MedicalCenter.Context;
using MedicalCenter.interfaces;
using MedicalCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Services
{
    public class SpecialityService : ISpecialityRepository
    {
        private readonly MedicalContext _context;

        public SpecialityService(MedicalContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Speciality>>> GetSpeciality()
        {
            var specialities = await _context.Speciality.ToListAsync();

            if (!specialities.Any())
            {
                throw new KeyNotFoundException("No Specialities found in the speciality list.");
            }

            return specialities;
        }

        public async Task<ActionResult<Speciality>> GetSpeciality(int id)
        {
            var speciality = await _context.Speciality.FindAsync(id);

            if (speciality == null)
            {
                throw new KeyNotFoundException("Speciality not found.");
            }

            return speciality;
        }

        public async Task<IActionResult> PutSpeciality(int id, Speciality speciality)
        {
            if (speciality == null)
            {
                throw new ArgumentNullException(nameof(speciality));
            }

            if (id != speciality.SpecialityID)
            {
                throw new ArgumentException("Speciality ID mismatch.");
            }

            if (!_context.Speciality.Any(e => e.SpecialityID == speciality.SpecialityID))
            {
                throw new KeyNotFoundException("Speciality not found.");
            }

            _context.Entry(speciality).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<ActionResult<Speciality>> PostSpeciality(Speciality speciality)
        {
            if (speciality == null)
            {
                throw new ArgumentNullException(nameof(speciality));
            }

            _context.Speciality.Add(speciality);
            await _context.SaveChangesAsync();

            return speciality;
        }

        public async Task<IActionResult> DeleteSpeciality(int id)
        {
            var speciality = await _context.Speciality.FindAsync(id);
            if (speciality == null)
            {
                throw new KeyNotFoundException("Speciality not found.");
            }

            _context.Speciality.Remove(speciality);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
