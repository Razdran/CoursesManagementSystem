using CourseLab.Data.UserManagement;
using Function.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLab.Web.Models
{
    public class ScheduleModel
    {
        public Guid Id { get; set; }
        public string Group { get; set; }
        public YearEnum Year { get; set; }
        public string Object { get; set; }
        public string Professor { get; set; }
        public DayEnum Day { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
