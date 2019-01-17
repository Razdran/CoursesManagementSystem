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

        public List<string> GetAllFullName()
        {
           var list = professorRepository.GetAll();
            if (list == null)
                return null;
            var namelist = new List<string>();
            foreach(var item in list)
            {
                namelist.Add(item.FirstName + " " + item.LastName);
            }
            return namelist;
        }

        public ProfessorDto GetByFullName(string fullname)
        {
            var list = fullname.Split(' ');
            var prof = professorRepository.Query(x => x.FirstName == list[0] && x.LastName == list[1]).SingleOrDefault();
            var dto = (ProfessorDto)new ProfessorDto().InjectFrom(prof);
            return dto;
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

        public string GetFullName(Guid id)
        {
            var prof= professorRepository.GetById(id);
            if (prof == null)
                return null;
            return prof.FirstName + " " + prof.LastName;
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

