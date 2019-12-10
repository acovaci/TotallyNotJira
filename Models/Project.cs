using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TotallyNotJira.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext() : base("DBConnectionString") { }
        public DbSet<Project> Projects { get; set; }
    }
}