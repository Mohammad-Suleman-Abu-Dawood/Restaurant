using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterItemMenuModel
    {
        [Key]
        public int MasterItemMenuId { get; set; }

        public int? MasterCategoryMenuId { get; set; }

        public string? MasterItemMenuTitle { get; set; }

        public string? MasterItemMenuBreef { get; set; }

        public string? MasterItemMenuDesc { get; set; }

        public string? MasterItemMenuInfo { get; set; }

        public decimal? MasterItemMenuPrice { get; set; }

        public string? MasterItemMenuImageUrl { get; set; }

        public DateTime? MasterItemMenuDate { get; set; }

        public virtual MasterCategoryMenu? MasterCategoryMenulink { get; set; }
        public bool? IsActive { get; set; }





        public IFormFile? Files { get; set; }
    }
}
