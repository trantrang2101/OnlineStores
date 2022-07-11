using System;
using System.Collections.Generic;

#nullable disable

namespace Project.Models
{
    public partial class FeedbackShipper
    {
        public int FeedbackId { get; set; }
        public int? Rate { get; set; }
        public bool? Comment { get; set; }

        public virtual Feedback Feedback { get; set; }
    }
}
