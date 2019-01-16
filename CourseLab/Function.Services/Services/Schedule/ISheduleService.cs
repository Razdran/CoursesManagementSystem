using Function.Services.Services.Schedule.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Function.Services.Services.Schedule
{
    public interface ISheduleService
    {
        ScheduleDto GetById(Guid id);
        List<ScheduleDto> GetByGroupAndYear(string group, int year);

    }
}
