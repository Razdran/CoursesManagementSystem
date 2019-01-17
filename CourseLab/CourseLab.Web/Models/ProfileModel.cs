using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLab.Web.Models
{
    public class ProfileModel
    {
        public StudentRegisterModel Profile { get; set; }
        public List<SubscriptionModel> Subscriptions { get; set; }
    }
}
