using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProductCatalog.Api.Domain.Product
{
    public class Product : ValueObject
    {
        [JsonProperty] public string Name { get; }
        [JsonProperty] public double Price { get; }
        [JsonProperty] public double Quantity { get; }

        public Product(string name, double price, double quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Price;
            yield return Quantity;
        }
    }
}