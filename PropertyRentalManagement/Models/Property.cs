using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyRentalManagement.Models
{
    public class Property
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(255)]
        [Display(Name = "App#")]
        public string AppartmentNumber { get; set; }

        [Required]
        [Display(Name = "Number Rooms")]
        public string NumberRooms { get; set; }

        [Required]
        [Display(Name = "Monthly Price $")]
        public int Price { get; set; }

        public BuildingType BuildingType { get; set; }
        [Required]
        [Display(Name = "Building Type")]
        public int BuildingTypeId { get; set; }


        [Display(Name = "Rent Start")]
        public DateTime? RentStarted { get; set; }

        [Display(Name = "Rent finished")]
        public DateTime? RentFinished { get; set; }

        [Required]
        public bool Available { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}