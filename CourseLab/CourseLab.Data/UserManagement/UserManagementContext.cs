using System;
using Microsoft.EntityFrameworkCore;
using CourseLab.Data;
using CourseLab.Data.UserManagement.Entities;

namespace CourseLab.Data.UserManagement
{
    public class UserManagementContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=UserManagementDb;Trusted_Connection=True;");
        }
    }
}
