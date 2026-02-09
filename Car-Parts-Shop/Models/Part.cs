namespace Car_Parts_Shop.Models;

public class Part
{
    public Part(
        string partNumber,
        string name,
        string category,
        string countryOfOrigin,
        int warrantyYears,
        decimal price,
        bool canExpire = false,
        int expiryYears = 0)
    {
        SerialNumber = Guid.NewGuid().ToString("N");
        PartNumber = partNumber;
        Name = name;
        Category = category;
        CountryOfOrigin = countryOfOrigin;
        WarrantyYears = warrantyYears;
        Price = price;
        CanExpire = canExpire;
        ExpiryYears = expiryYears;
        BatchDate = DateTime.UtcNow.Date;
    }

    public string SerialNumber { get; }
    public string PartNumber { get; }
    public string Name { get; }
    public string Category { get; }
    public string CountryOfOrigin { get; }
    public DateTime BatchDate { get; }
    public bool CanExpire { get; }
    public int ExpiryYears { get; }
    public decimal Price { get; }
    public int WarrantyYears { get; }

    public DateTime? ExpiryDate => CanExpire ? BatchDate.AddYears(ExpiryYears) : null;
}
