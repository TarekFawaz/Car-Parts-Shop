using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Parts_Shop
{

    // This is for training purposes 
    public class part
    {
        public string SerialNo;
        public string partNo;
        public string Brand;
        public string countryOfOrigin;
        public DateTime batchDate;
        public bool CanExpire;
        public int ExpiryYears;
        public decimal CostPrice;
        public decimal sellingPrice;
        public int warrnty;
        public bool hasWarrnty;

        public DateTime GetExpiryDate
        {
            get
            {
                if (CanExpire)
                {
                    return batchDate.AddYears(ExpiryYears);
                }

                return DateTime.MinValue;
            }
            
        }

        public override string ToString()
        {
            return this.SerialNo;
        }



    }

    public class SeatBelt: part
    {
        public decimal thikness;
        public string color;

    }
     
    public class SalesLine
    {
        public part item;
        public int quantity;
        public decimal discount=0;

        private decimal GetDiscountValue()
        {
            return item.sellingPrice * (discount / 100);
        }
        public decimal GetTotal()
        {

            return (item.sellingPrice - GetDiscountValue() ) * quantity;
        }

    }

    public class Customer
    {
        public string fullName;
        public string address;
        public string mobileNo;
    }

    public class Invoice
    {
        public string serialNo;
        public Customer customer;
        public DateTime invoiceDate;
        public List<SalesLine> salesLines;
        public decimal taxPercentage;
        public decimal discount;

        public decimal invoiceTotalExTax
        {
            get
            {
                decimal total = 0;
                decimal dicsountValue = 0;
                foreach (SalesLine salesline in salesLines)
                {
                    total += salesline.GetTotal();
                }
                // calcuate discount 
                dicsountValue = total * (discount / 100);
                return total - dicsountValue;
            }                       
        }

        public decimal taxValue
        {
            get
            {
                return invoiceTotalExTax * (taxPercentage / 100);
            }
        }


        public decimal invoiceTotalIncTax
        {
            get
            {
                return invoiceTotalExTax + taxValue;
            }
        }

    }


    class Program
    {
        static List<part> inventory = new List<part>();
        static void Main(string[] args)
        {

            
            Random rnd = new Random(500);
            for (int i=0; i<10;i++)
            {
                part testpart = new part()
                {
                    SerialNo = rnd.Next().ToString(),
                    batchDate = new DateTime(2019, 11, 11),
                    Brand = "testBrand"+i,
                    CanExpire = false,
                    CostPrice = 50,
                    countryOfOrigin = "Egypt",
                    ExpiryYears = 0,
                    hasWarrnty = true,
                    partNo = "SDF44665",
                    sellingPrice = 90,
                    warrnty = 3
                };


                inventory.Add(testpart);
            }

            for (int i = 0; i < 5; i++)
            {
                part testpart = new SeatBelt()
                {
                    SerialNo = rnd.Next().ToString(),
                    batchDate = new DateTime(2019, 11, 11),
                    Brand = "testBrand" + i,
                    CanExpire = false,
                    CostPrice = 50,
                    countryOfOrigin = "Egypt",
                    ExpiryYears = 0,
                    hasWarrnty = true,
                    partNo = "SDF44665",
                    sellingPrice = 90,
                    warrnty = 3,
                    color = "red",
                    thikness = 5.5m
                };


                inventory.Add(testpart);
            }

            printInventoryCount();

        }


        static public void printInventoryCount()
        {
            if(inventory.Count>0)
            {
                int BeltsCount = 0;
                int genralPartCount = 0;
                foreach(part belt in inventory)
                {
                    if(belt.GetType() == typeof(SeatBelt))
                    {
                        BeltsCount++;
                    }
                    
                    if(belt.GetType()== typeof(part))
                    {
                        genralPartCount++;
                    }
                }

                Console.WriteLine($"General Items = {genralPartCount}");
                Console.WriteLine($"Belts Count {BeltsCount}");
            }
            else
            {
                Console.WriteLine("No Items Found");
            }
        }
            
    }
}
