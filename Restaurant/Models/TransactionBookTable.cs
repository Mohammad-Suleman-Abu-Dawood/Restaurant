using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class TransactionBookTable : BaseEntity
{
    public int TransactionBookTableId { get; set; }
    [DisplayName("FullName ")]
    public string? TransactionBookTableFullName { get; set; }
    [DisplayName("Email ")]
    public string? TransactionBookTableEmail { get; set; }
    [DisplayName("MobileNumber ")]
    public int? TransactionBookTableMobileNumber { get; set; }
    [DisplayName("TableDate ")]
    public DateTime? TransactionBookTableDate { get; set; }
}
