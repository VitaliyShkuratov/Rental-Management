using Microsoft.AspNet.Identity.EntityFramework;
using PropertyRentalManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PropertyRentalManagement.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone number")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Roles")]
        public IEnumerable<string> RoleName { get; set; }

    }
}