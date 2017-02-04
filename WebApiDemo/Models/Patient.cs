using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models
{
    public class Patient : Person
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        public int Age { get; set; }
    }
}