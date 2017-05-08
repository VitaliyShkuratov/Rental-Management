using Microsoft.AspNet.Identity.EntityFramework;
using PropertyRentalManagement.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyRentalManagement.ViewModels
{
    public class EditPersonViewModel
    {

        public ApplicationUser CurrentApplicationUser { get; set; }
        //[Required]
        //[Display(Name = "Roles")]
        //public List<string> RoleName { get; set; }

        [Required]
        [Display(Name = "List of roles")]
        public IEnumerable<IdentityRole> ListOfRols;
    }
}