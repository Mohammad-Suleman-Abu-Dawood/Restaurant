using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Restaurant.Models;

public partial class TransactionNewsletter : BaseEntity
{
    public int TransactionNewsletterId { get; set; }
    [DisplayName("Email ")]
    public string? TransactionNewsletterEmail { get; set; }
}
