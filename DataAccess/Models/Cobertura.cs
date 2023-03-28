namespace SeguroAutoAPI.DataAccess.Models
{
    // Models/Cobertura.cs
    public class Cobertura
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoCubierto { get; set; }
        public Guid PolizaId { get; set; }
        public Poliza? Poliza { get; set; }
    }

}
