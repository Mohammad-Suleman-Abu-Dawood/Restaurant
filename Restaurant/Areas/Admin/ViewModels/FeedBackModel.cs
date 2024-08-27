using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class FeedBackModel
    {
        [Key]
        public int FeedBackId { get; set; }
        public string FeedBackMessage { get; set; }

        public string FeedBackImgUrl { get; set; }

        public string FeedBackName { get; set; }

        public string FeedBackRole { get; set; }

        public bool? IsActive { get; set; }
        [NotMapped]
        public IFormFile? Files { get; set; }
    }
}
