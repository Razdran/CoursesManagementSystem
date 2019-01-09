using CourseLab.Data.UserManagement.Infrastructure;
using System;
using System.Collections.Generic;
using Entities = CourseLab.Data.UserManagement.Entities;
using System.Text;
using CourseLab.Services.Services.Professor.Dtos;
using Omu.ValueInjecter;
using System.Linq;

namespace CourseLab.Services.Services.Professor
{
    public class ProfessorService : IProfessorService
    {
        private readonly IRepository<Entities.Professor> professorRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProfessorService(IRepository<Entities.Professor> professorRepository, IUnitOfWork unitOfWork)
        {
            this.professorRepository = professorRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateProfessor(ProfessorDto professorDto)
        {
            professorRepository.Add((Entities.Professor)new Entities.Professor().InjectFrom(professorDto));
            unitOfWork.Commit();
        }



        public List<ProfessorDto> GetAll()
        {
            var professorList = professorRepository.GetAll();
            var professorDtoList = new List<ProfessorDto>();
            foreach (var professor in professorList)
            {
                var professorDto = (ProfessorDto)new ProfessorDto().InjectFrom(professor);
                professorDtoList.Add(professorDto);
            }
            return professorDtoList;
        }

        public ProfessorDto GetById(Guid id)
        {
            var user = professorRepository.GetById(id);
            var userDto = (ProfessorDto)new ProfessorDto().InjectFrom(user);

            return userDto;
        }

        public ProfessorDto GetByUserId(Guid id)
        {
            var user = professorRepository.Query(x => x.UserId == id).FirstOrDefault();
            var userDto = (ProfessorDto)new ProfessorDto().InjectFrom(user);

            return userDto;
        }

        public void UpdateProfessor(ProfessorDto professorDto)
        {
            var professor = professorRepository.GetById(professorDto.Id);
            var professorDtoUpdate = (ProfessorDto)new ProfessorDto().InjectFrom(professor);

            professorDtoUpdate.UserId = professorDto.UserId;
            professorDtoUpdate.Object = professorDto.Object;
            
            professorDtoUpdate.Email = professorDto.Email;

            professorRepository.Update((Entities.Professor)professor.InjectFrom(professorDtoUpdate));
            unitOfWork.Commit();
        }


    }
}

