using PropertyRentalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyRentalManagement.ViewModels
{
    public class PropertyViewModel
    {
        public Property Property { get; set; }
        public IEnumerable<BuildingType> BuildingTypes { get; set; }
        public ImageModel ImageModel { get; set; }
        //public Dictionary<int, string> ListFilesNames { get; set; }
        public List<string> ListFilesNames { get; set; }
    }
}