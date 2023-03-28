namespace SeguroAutoAPI.DTO
{
    public class PolizaDTO
    {
        public Guid IdDTO { get; set; }
        public string NumeroPolizaDTO { get; set; }
        public string NombreClienteDTO { get; set; }
        public string IdentificacionClienteDTO { get; set; }
        public DateTime FechaNacimientoClienteDTO { get; set; }
        public DateTime FechaInicioPolizaDTO { get; set; }
        public DateTime FechaFinPolizaDTO { get; set; }
        public ICollection<CoberturaDTO> CoberturasDTO { get; set; }
        public decimal ValorMaximoCubiertoDTO { get; set; }
        public string NombrePlanDTO { get; set; }
        public string CiudadResidenciaDTO { get; set; }
        public string DireccionResidenciaDTO { get; set; }
        public string PlacaAutomotorDTO { get; set; }
        public string ModeloAutomotorDTO { get; set; }
        public bool VehiculoTieneInspeccionDTO { get; set; }
    }

}
