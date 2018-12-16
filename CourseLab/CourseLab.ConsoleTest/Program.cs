using System;
using CourseLab.Data.UserManagement;
using CourseLab.Data.UserManagement.Entities;
using CourseLab.Data.UserManagement.Infrastructure;

namespace CourseLab.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new UserManagementContext();
            var u = new UnitOfWork(x);
            var y = new Repository<User>(x);
            var z = new User() { Id = Guid.NewGuid(), IsDeleted = false, Password = "Y", Username = "X", UserRole = RoleEnum.Student };
            y.Add(z);
            u.Commit();
        }
    }
}
