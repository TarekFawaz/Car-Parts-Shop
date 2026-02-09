namespace Car_Parts_Shop.Models;

public class Invoice
{
    public required string SerialNumber { get; init; }
    public required Customer Customer { get; init; }
    public DateTime InvoiceDate { get; init; } = DateTime.UtcNow;
    public List<SalesLine> SalesLines { get; } = new();
    public decimal TaxPercentage { get; set; }
    public decimal DiscountPercent { get; set; }

    public decimal InvoiceTotalExTax
    {
        get
        {
            var total = SalesLines.Sum(line => line.GetTotal());
            var discountValue = total * (DiscountPercent / 100m);
            return total - discountValue;
        }
    }

    public decimal TaxValue => InvoiceTotalExTax * (TaxPercentage / 100m);

    public decimal InvoiceTotalIncTax => InvoiceTotalExTax + TaxValue;
}
