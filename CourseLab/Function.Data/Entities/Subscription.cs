using System;
using System.Collections.Generic;
using System.Text;

namespace Function.Data.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public Guid User { get; set; }
        public Guid Professor { get; set; }
        public bool IsDeleted { get; set; }
    }
}
