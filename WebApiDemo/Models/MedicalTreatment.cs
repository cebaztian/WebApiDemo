using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDemo.Models
{
    public class MedicalTreatment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        public string Diseases { get; set; }
        [Required]
        public List<Medicine> Medicines { get; set; }
        [Required]
        public long PatientId { get; set; }
        public Patient Patient { get; set; }
        [Required]
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}