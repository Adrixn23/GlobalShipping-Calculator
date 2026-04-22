namespace GlobalShipping.Core.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public decimal BaseShippingRate { get; set; } 
        public decimal MaxWeight { get; set; } // Limite de peso por pais
        public bool IsActive { get; set; } = true;
    }
}