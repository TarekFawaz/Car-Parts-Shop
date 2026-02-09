namespace Car_Parts_Shop.Models;

public class SeatBelt : Part
{
    public SeatBelt(
        string partNumber,
        string name,
        string category,
        string countryOfOrigin,
        int warrantyYears,
        decimal price,
        decimal thickness,
        string color)
        : base(partNumber, name, category, countryOfOrigin, warrantyYears, price)
    {
        Thickness = thickness;
        Color = color;
    }

    public decimal Thickness { get; }
    public string Color { get; }
}
