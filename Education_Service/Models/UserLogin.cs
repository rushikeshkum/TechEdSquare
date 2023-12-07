using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Education_Service.Models
{
    public class UserLogin
    {
        public int Id { get; set; }
        [Required]
        public string UserUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}