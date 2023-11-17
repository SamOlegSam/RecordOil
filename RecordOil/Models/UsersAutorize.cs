using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecordOil.Models
{
    public class UsersAutorize
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}