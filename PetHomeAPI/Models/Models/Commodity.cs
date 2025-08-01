using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Commodity
{
    public int Cid { get; set; }

    public string Cname { get; set; } = null!;

    public decimal Price { get; set; }

    public int Inventory { get; set; }

    public string? Describe { get; set; }

    public DateOnly ManufactureTiem { get; set; }

    public string Yieldly { get; set; } = null!;

    public int Expiration { get; set; }

    public int SalesVolume { get; set; }

    public DateOnly DateIssued { get; set; }
}
