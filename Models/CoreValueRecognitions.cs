using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIS4200_Team8_Scrum.Models
{
    public class CoreValueRecognitions
    {
        public int ID { get; set; }

        [Display(Name = "Recognition given to")]
        public Guid recognized { get; set; }

        [Display(Name = "Recognition given by")]
        public Guid recognizor { get; set; }
        
        [Display(Name = "Core Centric Value")]
        public CoreValue award { get; set; }

        [Display(Name = "Date Recognition is Given")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime recognizationDate { get; set; }

        public string Comments { get; set; }
        public enum CoreValue
        {
            Excellence = 1,
            Integrity = 2,
            Stewardship = 3,
            Accepting = 4,
            Innovative = 5,
            Balance = 6,
            Passion = 7
            
        }

        [ForeignKey("recognized")]
        public virtual Profile personRecognized { get; set; }

        [ForeignKey("recognizor")]
        public virtual Profile personRecognizor { get; set; }

    }
}