using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalCenter.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be longer than 2 characters")]
        public string Patient_Name { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [MinLength(3, ErrorMessage = "LastName must be longer than 2 characters")]
        public string Patient_LastName { get; set; }
        public String Birth_Date { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        [RegularExpression("(male|female)", ErrorMessage = "Gender must be Male or Female.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Adress is required.")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        [MinLength(7, ErrorMessage = "Phone number must have seven numbers.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

    }
}
