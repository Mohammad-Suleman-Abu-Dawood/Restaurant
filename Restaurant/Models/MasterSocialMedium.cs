using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterSocialMedium : BaseEntity
{
    
    public int MasterSocialMediumId { get; set; }
    [DisplayName("Image ")]
    public string MasterSocialMediumImageUrl { get; set; } = null!;
    [DisplayName("Url ")]
    public string MasterSocialMediumUrl { get; set; } = null!;
}
