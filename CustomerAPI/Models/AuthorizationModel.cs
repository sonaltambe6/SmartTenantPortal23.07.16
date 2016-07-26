using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    public class ChangePasswordModel
    {

        [Required]
        //[LocalizedStringLength(100, ErrorMessage = "INVALID_PASSWORD_LENGTH", MinimumLength = 6)]
        [DataType(DataType.Password)]
        //[LocalizedDisplayName("NEW_PASSWORD")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        //[LocalizedDisplayName("CONFIRM_PASSWORD")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "PASSWORDS_DO_NOT_MATCH")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        //[Display(Name = "User Name")]
        //[Required]
        public string UserName { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[LocalizedDisplayName("PASSWORD")]
        public string Password { get; set; }

        //[LocalizedDisplayName("REMEMBER_ME")]
        public bool RememberMe { get; set; }

        public bool IsAdminView { get; set; }
   
    }
}
