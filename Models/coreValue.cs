using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200_Team8_Scrum.Models
{
    public class coreValue
    {
        [Key]
        public int coreValueId { get; set; }

        [Required(ErrorMessage = "Select most accurate core value.")]
        public string CoreValue { get; set; }
    }
}