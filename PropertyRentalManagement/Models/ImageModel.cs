using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyRentalManagement.Models
{
    public class ImageModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        //[Required]
        //public int PropertyId { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public string FileName{ get; set; }
        //[Required]
        //public string FilePath { get; set; }
        //[Required]
        //[Display(Name = "Image")]
        //public byte[] ImageData { get; set; }
        //[Required(ErrorMessage = "Please select image file")]
        //public HttpPostedFileBase File { get; set; }

    }
}