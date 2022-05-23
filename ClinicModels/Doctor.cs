using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectClinic.Models
{
    public class Doctor
    {
        [Key]
        [Required(ErrorMessage ="Enter DoctorId")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Enter Doctor_FirstName")]
        public string Doctor_FirstName { get; set; }

        [Required(ErrorMessage = "Enter Doctor_LastName")]
        public string Doctor_LastName { get; set; }

        [Required(ErrorMessage = "Enter Doctor_Sex")]
        public string Doctor_Sex { get; set; }

        [Required(ErrorMessage = "Enter Doctor_Specialisation")]
        public string Doctor_Specialisation { get; set; }

        [Required(ErrorMessage = "Enter Doctor_VisitingHours")]
        public string Doctor_VisitingHours { get; set; }
    }
}
