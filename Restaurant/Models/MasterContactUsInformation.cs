using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models;

public partial class MasterContactUsInformation : BaseEntity
{
    public int MasterContactUsInformationId { get; set; }

    public string? MasterContactUsInformationIdesc { get; set; }

    public string? MasterContactUsInformationImageUrl { get; set; }

    public string? MasterContactUsInformationRedirect { get; set; }

    public string? MasterContactUsInformationTitle { get; set; }

}
