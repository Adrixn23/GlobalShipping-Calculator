namespace GlobalShipping.Core.Interfaces
{
    public interface IShippingStrategy
    {
        // Define si la estrategia es aplicable a un país determinado.
        // Esto permite inyectar todas las estrategias y el sistema seleccionará la correcta automáticamente.
        bool CanHandle(string countryCode);
        
        // Define cómo se calculará la tarifa basados en el peso y la tarifa que provendrá de la BD.
        decimal Calculate(decimal weight, decimal baseRate);
    }
}