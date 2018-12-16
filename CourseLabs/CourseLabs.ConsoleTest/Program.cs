using System;
using System.Collections.Generic;
using System.Linq;
using CourseLabs.Data;
using CourseLabs.Data.UserManagement;
using CourseLabs.Data.UserManagement.Entities;
using CourseLabs.Data.UserManagement.Infrastructure;

namespace CourseLabs.ConsoleTest
{
    public class Program
    {
        static void Main(string[] args)
        {

           
            var q = new UserManagementContext();
            var x = new Data.UserManagement.Infrastructure.Repository<User>(q);
            var u = new UnitOfWork(q);
            x.Add(new User() { Id = Guid.NewGuid(), FirstName = "name", LastName = "name2", UserRole = RoleEnum.Student, IsDeleted = false });
            u.Commit();
            var z = x.GetAll();
            foreach(var o in z)
            {
                Console.WriteLine(o.IsDeleted);
            }
        }
    }
}
