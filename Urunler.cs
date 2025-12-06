using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeverM
{
    using System;

    namespace StokTakip
    {
        public enum Category
        {
            Gida,
            Elektronik,
            Giyim,
            Temizlik
        }

        public class Product
        {
            public string Name { get; set; }
            public Category Category { get; set; }
            public decimal Price { get; private set; }
            public int Stock { get; private set; }
            public bool IsCampaign { get; set; }
            public decimal CampaignPrice { get; set; }

            public Product(string name, Category category, decimal price, int stock)
            {
                Name = name;
                Category = category;
                Price = price;
                Stock = stock;
            }

            public void IncreaseStock(int amount)
            {
                Stock += amount;
            }

            public bool DecreaseStock(int amount)
            {
                if (Stock - amount < 0) return false;
                Stock -= amount;
                return true;
            }

            public void UpdatePrice(decimal newPrice)
            {
                Price = newPrice;
            }
        }
    }

}
