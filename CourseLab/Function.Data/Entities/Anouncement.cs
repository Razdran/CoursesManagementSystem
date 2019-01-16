
using System;
using System.Collections.Generic;
using System.Text;

namespace Function.Data.Entities
{
    public class Anouncement
    {
        public Guid Id { get; set; }
        public string Professor { get; set; }
        public string AnouncementText { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
