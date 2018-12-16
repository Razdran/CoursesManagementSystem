using System;
using Microsoft.EntityFrameworkCore;
using CourseLab.Data;
using CourseLab.Data.UserManagement.Entities;

namespace CourseLab.Data.UserManagement
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
