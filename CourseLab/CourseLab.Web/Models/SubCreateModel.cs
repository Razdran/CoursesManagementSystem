using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLab.Web.Models
{
    public class SubCreateModel
    {
        public string Name { get; set; }
        public List<string> Professors { get; set; }
    }
}
