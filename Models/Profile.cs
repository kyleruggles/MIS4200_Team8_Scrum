using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200_Team8_Scrum.Models
{
    public class Profile
    {

        public int profileId { get; set; }

        [Required(ErrorMessage = "Profile first name is required")]
        [StringLength(20)]
        public string profileFirstName { get; set; }

        [Required(ErrorMessage = "Profile last name is required")]
        [StringLength(20)]
        public string profileLastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter your most used email address")]
        [StringLength(20)]
        public string email { get; set; }

        public string password { get; set; }

        public string businessUnit { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$",
        ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]

        public string phoneNumber { get; set; }

        public string title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }

        public string fullName { get { return profileFirstName + ", " + profileLastName; } }

    }
}