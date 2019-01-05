using CourseLab.Services.Services.Objects.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseLab.Services.Services.Objects
{
    public interface IObjectService
    {
        ObjectDto GetbyId(Guid id);
        List<ObjectDto> GetAll();
        ObjectDto GetbyName(string name);
    }
}
