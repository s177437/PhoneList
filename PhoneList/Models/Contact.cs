using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneList.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}