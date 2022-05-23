using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectClinic.Models
{
    public class Patient
    {
        [Key]

        public int PatientId { get; set; }
        [Required(ErrorMessage = "Enter Patient_FirstName")]
        public string Patient_FirstName { get; set; }
        [Required(ErrorMessage = "Enter Patient_LastName")]
        public string Patient_LastName { get; set; }
        [Required(ErrorMessage = "Enter Patient_Sex")]
        public string Patient_Sex { get; set; }
        //[Required(ErrorMessage = "Enter Patient_Age")]
        //[Range(1, 120, ErrorMessage = "Enter Valid Age  ")]
        public int Patient_Age { get; set; }
        [Required(ErrorMessage = "Enter Patient_Date_Of_Birth")]        
        public string Patient_DOB { get; set; }
    }
}
