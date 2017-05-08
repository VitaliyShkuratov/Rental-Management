using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropertyRentalManagement.Models
{
    public class PropertyImageModel
    {
        [Key, Column(Order = 0)]
        public int ImageModelId { get; set; }
        [Key, Column(Order = 1)]
        public int PropertyId { get; set; }
    }
}