using System;
using System.Collections.Generic;
using CourseLab.Services.Services.User.Dto;

namespace CourseLab.Services.Services.User
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetById(Guid id);
        void CreateUser(UserDto userDto);
        void UpdateUser(UserDto userDto);
    }
}
