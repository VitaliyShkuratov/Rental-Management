using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyRentalManagement.Models
{
    public class BookAppointmenModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime startDate { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime startTime { get; set; }
        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }
    }
}