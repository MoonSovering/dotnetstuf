using MedicalCenter.Interfaces;
using MedicalCenter.Models;
using MedicalCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenter.Services
{
    public class DoctorService: IDoctorRepository
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var doctors = await _doctorRepository.GetDoctors();

            if (!doctors.Value.Any())
            {
                throw new KeyNotFoundException("No Doctors found in the doctor list.");
            }

            return doctors;
        }

        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _doctorRepository.GetDoctor(id);

            if (doctor.Value == null)
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

            var existingDoctor = await _doctorRepository.GetDoctor(doctor.DoctorID);
            if (existingDoctor.Value == null)
            {
                throw new KeyNotFoundException("Doctor not found.");
            }

            return await _doctorRepository.PutDoctor(id, doctor);
        }

        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            return await _doctorRepository.PostDoctor(doctor);
        }

        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorRepository.GetDoctor(id);
            if (doctor.Value == null)
            {
                throw new KeyNotFoundException("Doctor not found.");
            }

            return await _doctorRepository.DeleteDoctor(id);
        }
    }
}
