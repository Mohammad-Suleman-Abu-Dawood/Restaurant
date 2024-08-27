using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class MasterService : BaseEntity
{
    public int MasterServiceId { get; set; }
    [DisplayName("Title ")]
    public string? MasterServicesTitle { get; set; }
    [DisplayName("Desc ")]
    public string? MasterServicesDesc { get; set; }
    [DisplayName("Image ")]
    public string? MasterServicesImage { get; set; }
    public string? ICon { get; set; }
}
