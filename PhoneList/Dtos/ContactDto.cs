using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneList.Dtos
{
    public class ContactDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
}
}
