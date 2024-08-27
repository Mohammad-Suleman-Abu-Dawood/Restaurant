using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class MasterOffer : BaseEntity
{
    public int MasterOfferId { get; set; }
    [DisplayName("Title ")]
    public string? MasterOfferTitle { get; set; }
    [DisplayName("Breef ")]
    public string? MasterOfferBreef { get; set; }
    [DisplayName("Desc ")]
    public string? MasterOfferDesc { get; set; }
    [DisplayName("Image ")]
    public string? MasterOfferImageUrl { get; set; }
}
