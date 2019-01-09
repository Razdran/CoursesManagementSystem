using System;
using System.Collections.Generic;
using CourseLab.Services.Services.User.Dto;

namespace CourseLab.Services.Services.User
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetById(Guid id);
        UserDto GetByUsername(string username);
        void CreateUser(UserDto userDto);
        void UpdateUser(UserDto userDto);
        UserDto GetByUsernamePassword(string username, string password);
    }
}
