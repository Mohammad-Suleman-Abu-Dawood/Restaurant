using Restaurant.Models;

namespace Restaurant.Areas.Admin.ViewModels
{
    public class MasterMenuModel : BaseEntity
    {
        public MasterMenu? MasterMenu { get; set; }
        public List<MasterMenu>? ListMasterMenu { get; set; }
    }
}
