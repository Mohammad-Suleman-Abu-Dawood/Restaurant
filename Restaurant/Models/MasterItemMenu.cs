using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class MasterItemMenu : BaseEntity
{
    public int MasterItemMenuId { get; set; }

    public int? MasterCategoryMenuId { get; set; }

    public string? MasterItemMenuTitle { get; set; }

    public string? MasterItemMenuBreef { get; set; }

    public string? MasterItemMenuDesc { get; set; }

    public string? MasterItemMenuInfo { get; set; }

    public decimal? MasterItemMenuPrice { get; set; }

    public string? MasterItemMenuImageUrl { get; set; }

    public DateTime? MasterItemMenuDate { get; set; }

    public virtual MasterCategoryMenu? MasterCategoryMenu { get; set; }


}
