using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PropertyRentalManagement.ViewModels
{
    public class DetailUserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Email confirmed")]
        public bool EmailConfirmed { get; set; }


        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        [Display(Name = "Phone number confirmed")]
        public bool PhoneConfirmed { get; set; }

        [Display(Name = "Roles")]
        public List<string> RoleName { get; set; }
    }
}