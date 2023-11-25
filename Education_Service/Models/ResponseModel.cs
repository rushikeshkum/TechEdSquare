using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education_Service.Models
{
    public class ResponseModel
    {
        public int Code { get; set; }
        public dynamic Message { get; set; }
    }
}