using System;
using System.Collections.Generic;
using System.Text;

namespace Function.Services.Services.Subscription.Dto
{
    public class SubscriptionDto
    {
        public Guid Id { get; set; }
        public Guid User { get; set; }
        public Guid Professor { get; set; }
        public bool IsDeleted { get; set; }
    }
}
