using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyRentalManagement.Models
{
    public class BuildingType
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
}