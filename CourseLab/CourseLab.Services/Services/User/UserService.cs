using System;
using System.Collections.Generic;
using Entities = CourseLab.Data.UserManagement.Entities;
using CourseLab.Data.UserManagement.Infrastructure;
using CourseLab.Services.Services.User.Dto;
using Omu.ValueInjecter;

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
            userRepository.Add((Entities.User)new Entities.User().InjectFrom(userDto));
            unitOfWork.Commit();
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

            userRepository.Update((Entities.User) user.InjectFrom(userDtoUpdate));
            unitOfWork.Commit();
        }
    }
}
