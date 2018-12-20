using System;
using System.Collections.Generic;
using Entities = CourseLab.Data.UserManagement.Entities;
using CourseLab.Data.UserManagement.Infrastructure;
using CourseLab.Services.Services.User.Dto;
using Omu.ValueInjecter;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace CourseLab.Services.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Entities.User> userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<Entities.User> userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUser(UserDto userDto)
        {
            userDto.Password = Encrypt(userDto.Password);
            userDto.IsDeleted = false;
            userRepository.Add((Entities.User)new Entities.User().InjectFrom(userDto));
            unitOfWork.Commit();
        }

        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        public List<UserDto> GetAll()
        {
            var userList = userRepository.GetAll();
            var userDtoList = new List<UserDto>();
            foreach(var user in userList)
            {
                var userDto = (UserDto)new UserDto().InjectFrom(user);
                userDtoList.Add(userDto);
            }
            return userDtoList;
        }

        public UserDto GetById(Guid id)
        {
            var user = userRepository.GetById(id);
            var userDto = (UserDto)new UserDto().InjectFrom(user);

            return userDto;
        }

        public void UpdateUser(UserDto userDto)
        {
            var user = userRepository.GetById(userDto.Id);
            var userDtoUpdate = (UserDto)new UserDto().InjectFrom(user);

            userDtoUpdate.Username = userDto.Username;
            userDtoUpdate.Password = userDto.Password;
            userDtoUpdate.UserRole = userDto.UserRole;
            userDtoUpdate.IsDeleted = userDto.IsDeleted;

            userRepository.Update((Entities.User)user.InjectFrom(userDtoUpdate));
            unitOfWork.Commit();
        }

        public UserDto GetByUsernamePassword(string username,string password)
        {
            
            var user = userRepository.Query(x => x.Username == username && x.Password == Encrypt(password)).SingleOrDefault();
            if (user == null)
                return null;
            var userdto = (UserDto)new UserDto().InjectFrom(user);
            return userdto; 
        }

        
    }
}
