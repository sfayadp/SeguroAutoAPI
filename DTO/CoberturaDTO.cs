namespace SeguroAutoAPI.DTO
{
    public class CoberturaDTO
    {
        public Guid IdDTO { get; set; }
        public string NombreDTO { get; set; }
        public string DescripcionDTO { get; set; }
        public decimal MontoCubiertoDTO { get; set; }
        public Guid PolizaIdDTO { get; set; }
    }
}
