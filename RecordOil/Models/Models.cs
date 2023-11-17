using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecordOil.Models
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }       
    }
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }        
    }
}