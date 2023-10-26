using System;
using System.Collections.Generic;

namespace Aneta.Models;

public partial class PurchaseOrder
{
    public int OrderId { get; set; }

    public int? DocumentId { get; set; }

    public string? ModeOfProcurement { get; set; }

    public virtual TransactionDocument? Document { get; set; }
}
