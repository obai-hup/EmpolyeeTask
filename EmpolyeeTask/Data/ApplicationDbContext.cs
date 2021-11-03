using EmpolyeeTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpolyeeTask.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
           public DbSet<Employee> Employees { get; set; }
           //public DbSet<Country> Cuntries { get; set; }
           public DbSet<Department> Departments{ get; set; }
    }
}
