using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PropertyRentalManagement.Models
{
    public class EmailViewModel
    {
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "The Email field is not valid, Please enter a valid email address!")]
        [Required]
        public string From { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Subject")]
        [Required]
        public string Subject { get; set; }

        [DisplayName("Message")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Message { get; set; }
    }
}