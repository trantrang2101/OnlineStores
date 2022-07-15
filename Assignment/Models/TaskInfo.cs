using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class TaskInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
