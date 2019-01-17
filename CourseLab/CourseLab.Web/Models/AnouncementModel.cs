using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLab.Web.Models
{
    public class AnouncementModel
    {
        public Guid Id { get; set; }
        public string Professor { get; set; }
        public string AnouncementText { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
