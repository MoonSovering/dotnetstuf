using MedicalCenter.Context;
using MedicalCenter.Interfaces;
using MedicalCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Repository
{
    public class DoctorRepository: IDoctorRepository
    {
        private readonly MedicalContext _context;

        public DoctorRepository(MedicalContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }

        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            return doctor;
        }

        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }

        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
