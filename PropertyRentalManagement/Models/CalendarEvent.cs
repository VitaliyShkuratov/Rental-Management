using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyRentalManagement.Models
{
    public class CalendarEvent
    {
        [Required]
        //id, text, start_date and end_date properties are mandatory
        public int id { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        public DateTime start_date { get; set; }
        [Required]
        public DateTime end_date { get; set; }
    }
}