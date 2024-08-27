using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class TransactionContactU : BaseEntity
{
    public int TransactionContactUId { get; set; }
    [DisplayName("FullName ")]
    public string? TransactionContactUsFullName { get; set; }
    [DisplayName("Email ")]
    public string? TransactionContactUsEmail { get; set; }
    [DisplayName("Subject ")]
    public string? TransactionContactUsSubject { get; set; }
    [DisplayName("Message ")]
    public string? TransactionContactUsMessage { get; set; }
}
