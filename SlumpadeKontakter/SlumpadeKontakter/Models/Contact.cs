using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SlumpadeKontakter.Models
{

    public class Contact
    {
        public Guid ContactId { get; set; }

        [Required(ErrorMessage = "Namn måste anges")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Namnet måste vara 2-50 tkn")]
        [DisplayName("Namn")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Efternamn måste anges")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Beskrivning måste vara 2-50 tkn")]
        [DisplayName("Efternamn")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email måste anges")]
        [DisplayName("Email")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Namnet måste vara 3-50 tkn")]
        public string Email { get; set; }


        public Contact()
        {
            ContactId = Guid.NewGuid();
        }
    }
}



