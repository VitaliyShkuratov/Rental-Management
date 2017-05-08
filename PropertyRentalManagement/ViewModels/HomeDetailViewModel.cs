using PropertyRentalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyRentalManagement.ViewModels
{
    public class HomeDetailViewModel
    {
        public Property Property { get; set; }
        public List<string> ImageFileNames { get; set; }
    }
}