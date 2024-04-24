using MedicalCenter.Interfaces;
using MedicalCenter.Models;
using MedicalCenter.Repository;

namespace MedicalCenter.Services
{
    public class PatientService: IPatientRepository
    {
        private readonly PatientRepository _patientRepository;

        public PatientService(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _patientRepository.GetPatients();
        }

        public async Task<Patient> GetPatient(int id)
        {
            var patient = await _patientRepository.GetPatient(id);

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

            return await _patientRepository.AddPatient(patient);
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            if (!_patientRepository.GetPatients().Result.Any(e => e.PatientID == patient.PatientID))
            {
                throw new KeyNotFoundException("Patient not found.");
            }

            return await _patientRepository.UpdatePatient(patient);
        }

        public async Task DeletePatient(int id)
        {
            var patient = await _patientRepository.GetPatient(id);
            if (patient == null)
            {
                throw new KeyNotFoundException("Patient not found.");
            }

            await _patientRepository.DeletePatient(id);
        }
    }
}
