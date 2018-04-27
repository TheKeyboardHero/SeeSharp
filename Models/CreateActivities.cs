using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace BeltcSharp.Models
{

    public class CreateActivities
    {
        [Key]
        public int idActivity{ get; set; }
       
       [Required(ErrorMessage="Must fill in an Activity name with more than 2")]
       [MinLength(2)]
       public string Activity_Name { get; set; }

       public string Activity_Createdby { get; set; }


        [Required(ErrorMessage="Must fill in Activity Description")]
        [MinLength(10)]       
        public string Activity_Descript { get; set; }

       public string Duration { get; set; }
   

    //    public string Activity_Name{ get; set; }

        // [Required]
        // [Display(Name="Date of visit")]
        // [DataType(DataType.Date)]
        // [FutureDate(ErrorMessage="Date of visit should be in the future.")]
        // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public DateTime Activity_Date{ get; set; }


        public List<Attendees> Attendees{ get; set; }

        // public List<Users> Users{ get; set; }

        [ForeignKey("UserThatCreatedActivities")]
        public int CreatedByID { get; set; }
       
       public Users UserThatCreatedActivities { get; set; }

    


    }
    


}