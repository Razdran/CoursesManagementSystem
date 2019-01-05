using System;
using Entities = CourseLab.Data.UserManagement.Entities;
using CourseLab.Data.UserManagement.Infrastructure;
using CourseLab.Services.Services.Objects.Dto;
using Omu.ValueInjecter;
using System.Linq;
using System.Collections.Generic;

namespace CourseLab.Services.Services.Objects
{
    public class ObjectService : IObjectService
    {
        private readonly IRepository<Entities.Object> objectRepository;
        private readonly IUnitOfWork unitOfWork;

        public ObjectService(IRepository<Entities.Object> objectRepository, IUnitOfWork unitOfWork)
        {
            this.objectRepository = objectRepository;
            this.unitOfWork = unitOfWork;
        }

        public List<ObjectDto> GetAll()
        {
            var objlist = objectRepository.GetAll();
            var dtolist = new List<ObjectDto>();
            foreach(var obj in objlist)
            {
                var dto = (ObjectDto)new ObjectDto().InjectFrom(obj);
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public ObjectDto GetbyId(Guid id)
        {
            var obj = objectRepository.GetById(id);
            if (obj.IsDeleted == true)
                return null;
            else
            {
                var dto = (ObjectDto)new ObjectDto().InjectFrom(obj);
                return dto;
            }
        }

        public ObjectDto GetbyName(string name)
        {
            var obj = objectRepository.Query().Where(x => x.Name == name).SingleOrDefault();
            if (obj == null || obj.IsDeleted == true)
                return null;
            else
            {
                var dto = (ObjectDto)new ObjectDto().InjectFrom(obj);
                return dto;
            }
        }
    }
}
