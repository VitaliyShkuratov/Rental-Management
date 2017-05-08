using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyRentalManagement.ViewModels
{
    public class EditUserViewModel
    {
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
        public string UserName { get; set; }

        [Display(Name = "Phone number")]
        public string Phone { get; set; }
        // public ApplicationUser CurrentApplicationUser { get; set; }
        [Required]
        [Display(Name = "Roles")]
        public List<string> RoleName { get; set; }

        [Required]
        [Display(Name = "List of roles")]
        public IEnumerable<IdentityRole> ListOfRols;
    }
}