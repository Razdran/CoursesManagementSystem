﻿using CourseLab.Services.Services.Professor.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseLab.Services.Services.Professor
{
    public interface IProfessorService
    {
        List<ProfessorDto> GetAll();
        ProfessorDto GetById(Guid id);
        ProfessorDto GetByUserId(Guid id);
        void CreateProfessor(ProfessorDto professorDto);
        void UpdateProfessor(ProfessorDto professorDto);
    }
}
