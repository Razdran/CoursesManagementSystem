using CourseLab.Services.Services.Group.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseLab.Services.Services.Group
{
    public interface IGroupService
    {
        GroupDto GetbyId(Guid id);
        List<GroupDto> GetAll();
        GroupDto GetbyName(string name);
    }
}
