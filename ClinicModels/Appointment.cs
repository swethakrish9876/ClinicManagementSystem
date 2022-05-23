using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectClinic.Models
{
    public class Appointment
    {
        [Required(ErrorMessage = "Enter PatientId")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Enter Specialisation")]
        public string Specialisation { get; set; }
        [Required(ErrorMessage = "Enter Doctor Name")]
        public string Doctor { get; set; }
        [Required(ErrorMessage = "Enter Visit_Date")]
        public string Visit_Date { get; set; }
        [Required(ErrorMessage = "Enter Appointment_Time")]
        public string Appointment_Time { get; set; }
    }
}
