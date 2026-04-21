namespace GlobalShipping.Core.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty; // Ej: "IN", "US", "UK"
        
        // El valor base de la tarifa se leerá de la BD para cumplir con la escalabilidad de datos
        public decimal BaseShippingRate { get; set; } 
        
        public bool IsActive { get; set; } = true;
    }
}