using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenter.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorID { get; set; }

        [Required(ErrorMessage = "Doctor name is required.")]
        [MinLength(3, ErrorMessage = "Doctor Name must be longer than 2 characters")]
        public string Doctor_Name { get; set; }

        [Required(ErrorMessage = "Doctor last name is required.")]
        [StringLength(50, ErrorMessage = "Doctor last name cannot exceed 50 characters.")]
        [MinLength(3, ErrorMessage = "Doctor LastName must be longer than 2 characters")]
        public string Doctor_LastName { get; set; }

        [ForeignKey("SpecialityID")]
        public int SpecialityID { get; set; }

        public virtual Speciality? Speciality { get; set; }

        
    }
}
