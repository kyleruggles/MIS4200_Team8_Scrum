using System;
using System.Collections.Generic;
using System.Data.Entity;
using MIS4200_Team8_Scrum.Models;
using System.Linq;
using System.Web;

namespace MIS4200_Team8_Scrum.DAL
{
    public class MIS4200_Team8_Scrum_Context : DbContext
    {
        public System.Data.Entity.DbSet<MIS4200_Team8_Scrum.Models.Profile> Profiles { get; set; }
        public MIS4200_Team8_Scrum_Context() : base("name=DefaultConnection")
        {
            
        }
        
        
    }
}