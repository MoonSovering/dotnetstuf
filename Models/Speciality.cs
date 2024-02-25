using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedicalCenter.Models
{
    public class Speciality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpecialityID { get; set; }

        [Required(ErrorMessage = "Speciality is required.")]
        public string TypeSpeciality { get; set; }

    }
}
