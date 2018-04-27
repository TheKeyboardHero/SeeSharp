using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
 
namespace BeltcSharp.Models
{
    public class UsersContext : DbContext
    {
       
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }

        public DbSet<CreateActivities> Activities { get; set; }
        public DbSet<Attendees> Attendees { get; set; }

    }
}