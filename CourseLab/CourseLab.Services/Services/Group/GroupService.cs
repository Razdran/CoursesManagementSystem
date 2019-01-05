using System;
using System.Collections.Generic;
using System.Linq;
using CourseLab.Data.UserManagement.Infrastructure;
using CourseLab.Services.Services.Group.Dto;
using Omu.ValueInjecter;
using Entities = CourseLab.Data.UserManagement.Entities;

namespace CourseLab.Services.Services.Group
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Entities.Group> groupRepository;
        private readonly IUnitOfWork unitOfWork;

        public GroupService(IRepository<Entities.Group> groupRepository, IUnitOfWork unitOfWork)
        {
            this.groupRepository = groupRepository;
            this.unitOfWork = unitOfWork;
        }

        public GroupDto GetbyId(Guid id)
        {
            var group = groupRepository.GetById(id);
            if (group.IsDeleted == true)
                return null;
            else
            {
                var dto = (GroupDto)new GroupDto().InjectFrom(group);
                return dto;
            }
        }

        public List<GroupDto> GetAll()
        {
            var grouplist = groupRepository.GetAll();
            var dtolist = new List<GroupDto>();
            foreach (var group in grouplist)
            {
                var dto = (GroupDto)new GroupDto().InjectFrom(group);
                dtolist.Add(dto);
            }
            return dtolist;
        }

        public GroupDto GetbyName(string name)
        {
            var group = groupRepository.Query().Where(x => x.Name == name).SingleOrDefault();
            if (group == null || group.IsDeleted == true)
                return null;
            else
            {
                var dto = (GroupDto)new GroupDto().InjectFrom(group);
                return dto;
            }
        }
    }
}
