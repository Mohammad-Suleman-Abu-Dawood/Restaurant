using Restaurant.Models;
using System.ComponentModel;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterPartnerModel:BaseEntity
    {
        public int MasterPartnerId { get; set; }
        [DisplayName("Name ")]
        public string? MasterPartnerName { get; set; }
        [DisplayName("LogoImage ")]
        public string? MasterPartnerLogoImageUrl { get; set; }
        [DisplayName("WebsiteUrl ")]
        public string? MasterPartnerWebsiteUrl { get; set; }
        [DisplayName("Image ")]
        public IFormFile? File1 { get; set; }
        
        
    }
}
