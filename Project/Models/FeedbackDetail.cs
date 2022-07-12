#nullable disable

namespace Project.Models
{
    public partial class FeedbackDetail
    {
        public int FeedbackId { get; set; }
        public int ProductId { get; set; }
        public int? Rate { get; set; }
        public bool? Comment { get; set; }

        public virtual Feedback Feedback { get; set; }
        public virtual Product Product { get; set; }
    }
}
