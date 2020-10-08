using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;
using Xunit.Sdk;

namespace MIS4200_Team8_Scrum.Models
{
    public class coreValues
    {
        public int coreValuesId { get; set; }
        
        [Required(ErrorMessage = "Select most accurate core value.")]
        public string coreValue { get; set; }
    }
}