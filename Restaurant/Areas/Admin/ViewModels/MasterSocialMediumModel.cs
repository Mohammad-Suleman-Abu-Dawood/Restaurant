using Restaurant.Models;
using System.ComponentModel;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterSocialMediumModel:BaseEntity
    {
        public int MasterSocialMediumId { get; set; }
        [DisplayName("Image ")]
        public string MasterSocialMediumImageUrl { get; set; } = null!;
        [DisplayName("Url ")]
        public string MasterSocialMediumUrl { get; set; } = null!;
        public IFormFile? Files { get; set; }
    }
}
