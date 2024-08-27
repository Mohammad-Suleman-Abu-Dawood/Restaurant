using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class MasterPartner : BaseEntity
{
    public int MasterPartnerId { get; set; }
    [DisplayName("Name ")]
    public string? MasterPartnerName { get; set; }
    [DisplayName("Logo Image ")]
    public string? MasterPartnerLogoImageUrl { get; set; }
    [DisplayName("Url ")]
    public string? MasterPartnerWebsiteUrl { get; set; }
}
