using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class MasterWorkingHour : BaseEntity
{
    public int MasterWorkingHourId { get; set; }
    [DisplayName("Name ")]
    public string? MasterWorkingHourName { get; set; }
    [DisplayName("HourTimeFormTo ")]
    public string? MasterWorkingHourTimeFormTo { get; set; }
}
