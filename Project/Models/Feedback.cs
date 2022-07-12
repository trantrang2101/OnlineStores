#nullable disable

namespace Project.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int? Rate { get; set; }
        public bool? Comment { get; set; }
        public bool? Anonymous { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
