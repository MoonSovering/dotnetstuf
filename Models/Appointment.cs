using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalCenter.Models
{
    public class Appointment
    {
        public Appointment()
        {
            Date = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentID { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public Boolean Status { get; set; }

        [Required(ErrorMessage = "Doctor ID is required.")]

        [ForeignKey("DoctorID")]
        public int DoctorID { get; set; }

        [Required(ErrorMessage = "Patient ID is required.")]
        [ForeignKey("PatientID")]
        public int PatientID { get; set; }

        
        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }


    }
}
