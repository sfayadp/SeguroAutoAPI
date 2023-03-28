namespace SeguroAutoAPI.DataAccess.Models
{
    // Poliza.cs
    public class Poliza
    {
        public Guid Id { get; set; }
        public string NumeroPoliza { get; set; }
        public string NombreCliente { get; set; }
        public string IdentificacionCliente { get; set; }
        public DateTime FechaNacimientoCliente { get; set; }
        public DateTime FechaInicioPoliza { get; set; }
        public DateTime FechaFinPoliza { get; set; }
        public ICollection<Cobertura> Coberturas { get; set; }
        public decimal ValorMaximoCubierto { get; set; }
        public string NombrePlan { get; set; }
        public string CiudadResidencia { get; set; }
        public string DireccionResidencia { get; set; }
        public string PlacaAutomotor { get; set; }
        public string ModeloAutomotor { get; set; }
        public bool VehiculoTieneInspeccion { get; set; }
    }

}
