using System;
using CourseLab.Data.UserManagement;
using CourseLab.Data.UserManagement.Entities;
using CourseLab.Data.UserManagement.Infrastructure;
using CourseLab.Services.Services.User;

namespace CourseLab.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new UserManagementContext();
            var u = new UnitOfWork(x);
            var y = new Repository<User>(x);
            // var z = new User() { Id = Guid.NewGuid(), IsDeleted = false, Password = "Y", Username = "X", UserRole = RoleEnum.Student };
            //y.Add(z)

            /*TEST CreateUser*/
            var serviceUser = new UserService(y, u);
            //serviceUser.CreateUser(new Services.Services.User.Dto.UserDto() { Id = Guid.NewGuid(), IsDeleted = false, Password = "Y", Username = "Test", UserRole = RoleEnum.Student });

            /*TEST GetById*/
            var xId = Guid.Parse("e1bdb06d-12c2-4ce1-a10a-85c605c4ad9d");
            var xUser = serviceUser.GetById(xId);
            Console.WriteLine(xUser.Username.ToString());

            xUser.Username = "newUsername";
            serviceUser.UpdateUser(xUser);
            Console.WriteLine(xUser.Username.ToString());

            Console.ReadKey();
            //u.Commit();
        }
    }
}
