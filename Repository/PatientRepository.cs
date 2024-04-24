using MedicalCenter.Context;
using MedicalCenter.Interfaces;
using MedicalCenter.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenter.Repository
{
    public class PatientRepository: IPatientRepository
    {
        private readonly MedicalContext _context;

        public PatientRepository(MedicalContext context)
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
            return patient;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return patient;
        }

        public async Task DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}
