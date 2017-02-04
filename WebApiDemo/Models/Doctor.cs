using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models
{
    public class Doctor : Person
    {
        [Required]
        public string Specialty { get; set; }
    }
}