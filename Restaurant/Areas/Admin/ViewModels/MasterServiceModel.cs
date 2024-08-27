
using Restaurant.Models;
using System.ComponentModel;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterServiceModel:BaseEntity
    {
        public int MasterServiceId { get; set; }
        [DisplayName("Title ")]
        public string? MasterServicesTitle { get; set; }
        [DisplayName("Desc ")]
        public string? MasterServicesDesc { get; set; }
        [DisplayName("Image ")]
        public string? MasterServicesImage { get; set; }
        public IFormFile? Files { get; set; }
    }
}
