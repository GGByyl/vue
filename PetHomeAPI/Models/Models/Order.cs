using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Order
{
    public string OrderNumber { get; set; } = null!;

    public int OrderUserId { get; set; }

    public int OrderGoodsId { get; set; }

    public string OrderSite { get; set; } = null!;

    public int OrderState { get; set; }

    public int Principal { get; set; }

    public decimal? TotalPrices { get; set; }

    public int? Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public DateTime OrderTime { get; set; }
}
