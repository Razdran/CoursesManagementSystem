using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLab.Web.Models
{
    public class SubscriptionModel
    {
        public Guid Id { get; set; }
        public Guid User { get; set; }
        public string Professor { get; set; }
        public bool IsDeleted { get; set; }
    }
}
