using MedicalCenter.Interfaces;
using MedicalCenter.Models;
using MedicalCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCenter.Services
{
    public class SpecialityService: ISpecialityRepository
    {
        private readonly SpecialityRepository _specialityRepository;

        public SpecialityService(SpecialityRepository specialityRepository)
        {
            _specialityRepository = specialityRepository;
        }

        public async Task<ActionResult<IEnumerable<Speciality>>> GetSpeciality()
        {
            return await _specialityRepository.GetSpeciality();
        }

        public async Task<ActionResult<Speciality>> GetSpeciality(int id)
        {
            var speciality = await _specialityRepository.GetSpeciality(id);

            if (speciality.Value == null)
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

            var existingSpeciality = await _specialityRepository.GetSpeciality(speciality.SpecialityID);
            if (existingSpeciality.Value == null)
            {
                throw new KeyNotFoundException("Speciality not found.");
            }

            return await _specialityRepository.PutSpeciality(id, speciality);
        }

        public async Task<ActionResult<Speciality>> PostSpeciality(Speciality speciality)
        {
            if (speciality == null)
            {
                throw new ArgumentNullException(nameof(speciality));
            }

            return await _specialityRepository.PostSpeciality(speciality);
        }

        public async Task<IActionResult> DeleteSpeciality(int id)
        {
            var speciality = await _specialityRepository.GetSpeciality(id);
            if (speciality.Value == null)
            {
                throw new KeyNotFoundException("Speciality not found.");
            }

            return await _specialityRepository.DeleteSpeciality(id);
        }
    }
}
