using PropertyRentalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyRentalManagement.ViewModels
{
    public class HomeIndexViewModel
    {
        public Property Property{ get; set; }
        public string ImageFileName { get; set; }

    }
}