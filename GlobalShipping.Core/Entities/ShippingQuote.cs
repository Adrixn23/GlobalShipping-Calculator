namespace GlobalShipping.Core.Entities
{
    public class ShippingQuote
    {
        public string CountryName { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public decimal TotalCost { get; set; }
    }
}