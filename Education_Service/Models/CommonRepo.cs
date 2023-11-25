using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Education_Service.Models
{
    public class CommonRepo
    {
        internal static dynamic GetAdditionalValidationIssues(ModelStateDictionary modelState)
        {

            var errors = modelState.Select(x => x.Value.Errors)
                       .Where(y => y.Count > 0)
                       .ToList();

            string str = "";
            foreach (var item in errors)
            {
                str = str + "," + item[0].ErrorMessage.ToString();
            }
            return "Validation Failed" + str.Substring(1);
        }

        internal static object GetAdditionalValidationIssues(System.Web.Mvc.ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
    }
}