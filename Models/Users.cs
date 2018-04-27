using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BeltcSharp.Models
{
    public class Users{
       [Key]
       public int idUsers { get; set; }
       [Required(ErrorMessage="Must fill in a first name")]
    
       public string First_Name { get; set; }
       [Required(ErrorMessage="Must fill in a last name")]
       public string Last_Name { get; set; }

       [Required]
       [EmailAddress]

       public string Email { get; set; }

        [Required(ErrorMessage="Must be longer password and because I couldn't code it can you make sure to add 1 number and 1 special charecter thanks :)")]
        [MinLength(8, ErrorMessage="Must be longer password and because I couldn't code it can you make sure to add 1 number and 1 special charecter thanks :)")]
        [DataType(DataType.Password)]


       public string Password { get; set; }

    //    public DateTime Created_at { get; set; }


        public List<Attendees> Attendees{ get; set; }

        public List<CreateActivities> Activities{ get; set; }//Wedding
    }
}