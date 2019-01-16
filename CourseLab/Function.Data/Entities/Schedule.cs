using System;
using System.Collections.Generic;
using System.Text;

namespace Function.Data.Entities
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public string Group { get; set; }
        public string Professor { get; set; }
        public DayEnum Day { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
