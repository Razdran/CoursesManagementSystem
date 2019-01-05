using System;
using System.Collections.Generic;
using System.Text;

namespace CourseLab.Services.Services.Objects.Dto
{
    public class ObjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
