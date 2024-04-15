using MedicalCenter.Context;
using MedicalCenter.Controllers;
using MedicalCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCenter.Services
{
    public class DoctorService : IDoctorRepository
    {
        private readonly MedicalContext _context;

        public DoctorService(MedicalContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();

            if (!doctors.Any())
            {
                throw new KeyNotFoundException("No Doctors found in the doctor list.");
            }

            return doctors;
        }

        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                throw new KeyNotFoundException("Doctor not found.");
            }

            return doctor;
        }

        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            if (id != doctor.DoctorID)
            {
                throw new ArgumentException("Doctor ID mismatch.");
            }

            if (!_context.Doctors.Any(e => e.DoctorID == doctor.DoctorID))
            {
                throw new KeyNotFoundException("Doctor not found.");
            }

            _context.Entry(doctor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }

        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                throw new KeyNotFoundException("Doctor not found.");
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
