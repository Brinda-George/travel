using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelManagementSite.Models
{
    public class LoginModel
    {
        [DisplayName("Name")]
        [Required]
        public string name { get; set; }

        [DisplayName("Username")]
        [Required]
        public string username { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Less than 5 characters")]
        public string password { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Password not matched.")]
        [Required]
        public string confirmpassword { get; set; }

        [DisplayName("Gender")]
        public string gender { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string email { get; set; }

         [DisplayName("Mobile")]
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Enter a valid mobile number")]
        public string mobile { get; set; }

        [DisplayName("Location")]
        [Required]
        public string location { get; set; }
    }
}