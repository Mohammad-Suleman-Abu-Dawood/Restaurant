using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class MasterMenu : BaseEntity
{
    public int MasterMenuId { get; set; }
    [DisplayName("Name ")]
    public string? MasterMenuName { get; set; }
    [DisplayName("Url")]
    public string? MasterMenuUrl { get; set; } 
   
}
