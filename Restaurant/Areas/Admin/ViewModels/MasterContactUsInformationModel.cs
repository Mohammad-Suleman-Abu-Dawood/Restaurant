using Restaurant.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterContactUsInformationModel : BaseEntity
    {
        public int MasterContactUsInformationId { get; set; }

        public string? MasterContactUsInformationIdesc { get; set; }

        public string? MasterContactUsInformationImageUrl { get; set; }

        public string? MasterContactUsInformationRedirect { get; set; }
        public IFormFile? Files { get; set; }
        [DisplayName("Location")]
        public string? ourLocation { get; set; }
        [DisplayName("phone")]
        public string? ourphone { get; set; }
        [DisplayName("Mail")]
       
        public string? ourMail { get; set; }
    }
}
