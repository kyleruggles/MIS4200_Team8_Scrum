using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200_Team8_Scrum.Models
{
    public class Profile
    {
        [Key]
        public Guid ProfileId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Profile first name is required")]
        [StringLength(20)]
        public string profileFirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Profile last name is required")]
        [StringLength(20)]
        public string profileLastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Enter your most used email address")]
        [StringLength(20)]
        public string email { get; set; }

        [Display(Name = "Business Unit")]
        public string businessUnit { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$",
        ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        public string phoneNumber { get; set; }

        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }

        [Display(Name = "Employee Name")]
        public string fullName { get { return profileFirstName + ", " + profileLastName; } }
    }
}