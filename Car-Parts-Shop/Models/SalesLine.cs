namespace Car_Parts_Shop.Models;

public class SalesLine
{
    public required Part Item { get; init; }
    public int Quantity { get; set; }
    public decimal DiscountPercent { get; set; }

    public decimal GetTotal()
    {
        var discountValue = Item.Price * (DiscountPercent / 100m);
        return (Item.Price - discountValue) * Quantity;
    }
}
