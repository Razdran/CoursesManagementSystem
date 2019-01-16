using System;
using System.Collections.Generic;
using System.Text;

namespace Function.Services.Services.Anouncement.Dto
{
    public class AnouncementDto
    {
        public Guid Id { get; set; }
        public string Professor { get; set; }
        public string AnouncementText { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
