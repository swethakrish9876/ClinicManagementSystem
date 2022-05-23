using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectClinic.Models
{
    public class CancelAppoint
    {
        [Required(ErrorMessage = "Enter PatientId")]
        public int PatientId { get; set; }
    }
}
