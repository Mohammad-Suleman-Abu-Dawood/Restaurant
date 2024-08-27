using Restaurant.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterCategoryMenuModel
    {
        [Key]
        public int MasterCategoryMenuId { get; set; }
        [Required(ErrorMessage = "Fill")]
        public string? MasterCategoryMenuName { get; set; }


        public bool? IsActive { get; set; }
    }
}
