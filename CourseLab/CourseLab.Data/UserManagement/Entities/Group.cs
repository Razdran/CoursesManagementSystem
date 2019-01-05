﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CourseLab.Data.UserManagement.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
