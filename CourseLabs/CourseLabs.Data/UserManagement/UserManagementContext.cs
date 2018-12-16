using System;
using Microsoft.EntityFrameworkCore;
using CourseLabs.Data;
using CourseLabs.Data.UserManagement.Entities;

namespace CourseLabs.Data
{
    public class UserManagementContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=UserManagementDb;User Id=sa;Password=Cosminbbx1;");
        }
    }
}
