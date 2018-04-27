using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BeltcSharp.Models
{

    public class Attendees
    {

        [Key]
       public int idAttendees { get; set; }

       [ForeignKey("UserAttendingActivities")]
       public int Users_idUsers { get; set; }

       [ForeignKey("ActivityBeingAttended")]
       public int CreateActivities_idActivities { get; set; }
       public CreateActivities ActivityBeingAttended { get; set; }
       public Users UserAttendingActivities { get; set; }







    }
}