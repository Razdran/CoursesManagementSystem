using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Function.Data.Infrastructure;
using Function.Services.Services.Schedule.Dto;
using Omu.ValueInjecter;

namespace Function.Services.Services.Schedule
{
    public class ScheduleService : ISheduleService
    {
        private readonly IRepository<Data.Entities.Schedule> scheduleRepository;
        private readonly IUnitOfWork unitOfWork;

        public ScheduleService(IRepository<Data.Entities.Schedule> scheduleRepository, IUnitOfWork unitOfWork)
        {
            this.scheduleRepository = scheduleRepository;
            this.unitOfWork = unitOfWork;
        }
        public List<ScheduleDto> GetByGroupAndYear(string group, int year)
        {
            var list = scheduleRepository.Query(x => x.Group == group && x.Year == year && x.IsDeleted == false).ToList();
            var dtolist = new List<ScheduleDto>();
            foreach(var item in list)
            {
                var dto = (ScheduleDto)new ScheduleDto().InjectFrom(item);
                dtolist.Add(dto);
            }
            var sortedlist = dtolist.OrderBy(x => x.Day).ThenBy(x => x.StartTime).ToList();
            return sortedlist;
        }

        public ScheduleDto GetById(Guid id)
        {
            var entity = scheduleRepository.GetById(id);
            if (entity == null || entity.IsDeleted == true)
                return null;
            var entitydto = (ScheduleDto)new ScheduleDto().InjectFrom(entity);
            return entitydto;
        }
    }
}
