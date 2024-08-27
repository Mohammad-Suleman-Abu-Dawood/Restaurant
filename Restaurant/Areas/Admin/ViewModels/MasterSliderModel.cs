using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterSliderModel
    {
        [Key]
        public int MasterSliderId { get; set; }

        public string? MasterSliderTitle { get; set; }

        public string? MasterSliderBreef { get; set; }

        public string? MasterSliderDesc { get; set; }

        public string? MasterSliderUrl { get; set; }

        public string? MasterSliderUrl2 { get; set; }
        public bool? Active { get; set; }

        [NotMapped]
        public IFormFile? files { get; set; }

    }
}
