using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Education_Service.Models
{
    public class AdminLogin
    {
        public int id { get; set; }

        [Required]
        public string UsernameAdmin { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string PasswordAdmin { get; set; }
    }
}