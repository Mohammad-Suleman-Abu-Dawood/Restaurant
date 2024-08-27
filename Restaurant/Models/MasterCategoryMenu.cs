using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class MasterCategoryMenu :BaseEntity
{
    public int MasterCategoryMenuId { get; set; }
    [DisplayName("Name")]
    public string? MasterCategoryMenuName { get; set; }

    
}
