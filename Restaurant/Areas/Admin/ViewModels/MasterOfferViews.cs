using Restaurant.Models;
using System.ComponentModel;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterOfferViews : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterOfferId { get; set; }
        [DisplayName("Title")]
        public string? MasterOfferTitle { get; set; }
        [DisplayName("Breef")]
        public string? MasterOfferBreef { get; set; }
        [DisplayName("Description")]
        public string? MasterOfferDesc { get; set; }
        [DisplayName("ImageUrl")]
        public string? MasterOfferImageUrl { get; set; }
        [DisplayName("Image")]

        public IFormFile? Files { get; set; }
    }
}
