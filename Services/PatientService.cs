using MedicalCenter.Context;
using MedicalCenter.interfaces;
using MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Services
{
    public class PatientService : IPatientRepository
    {
        private readonly MedicalContext _context;

        public PatientService(MedicalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                throw new KeyNotFoundException("Patient not found.");
            }

            return patient;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            if (!_context.Patients.Any(e => e.PatientID == patient.PatientID))
            {
                throw new KeyNotFoundException("Patient not found.");
            }

            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                throw new KeyNotFoundException("Patient not found.");
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}
