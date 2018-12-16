using System;
using System.Collections.Generic;
using CourseLab.Data.UserManagement.Entities;
using CourseLab.Data.UserManagement.Infrastructure;
using CourseLab.Services.Services.User.Dto;
using Omu.ValueInjecter;

namespace CourseLab.Services.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Data.UserManagement.Entities.User> userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<Data.UserManagement.Entities.User> userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUser(UserDto userDto)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
