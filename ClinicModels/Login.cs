using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace ProjectClinic.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter UserName")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "special characters not allowed")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string Passwrd { get; set; }
    }

}
