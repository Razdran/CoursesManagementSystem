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
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Entities.Object> Objects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=UserManagementDb;Trusted_Connection=True;");
        }
    }
}
