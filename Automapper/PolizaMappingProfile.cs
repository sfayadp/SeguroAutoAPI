using AutoMapper;
using SeguroAutoAPI.DataAccess.Models;
using SeguroAutoAPI.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Poliza, PolizaDTO>()
            .ForMember(dest => dest.IdDTO, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NumeroPolizaDTO, opt => opt.MapFrom(src => src.NumeroPoliza))
            .ForMember(dest => dest.NombreClienteDTO, opt => opt.MapFrom(src => src.NombreCliente))
            .ForMember(dest => dest.IdentificacionClienteDTO, opt => opt.MapFrom(src => src.IdentificacionCliente))
            .ForMember(dest => dest.FechaNacimientoClienteDTO, opt => opt.MapFrom(src => src.FechaNacimientoCliente))
            .ForMember(dest => dest.FechaInicioPolizaDTO, opt => opt.MapFrom(src => src.FechaInicioPoliza))
            .ForMember(dest => dest.FechaFinPolizaDTO, opt => opt.MapFrom(src => src.FechaFinPoliza))
            .ForMember(dest => dest.ValorMaximoCubiertoDTO, opt => opt.MapFrom(src => src.ValorMaximoCubierto))
            .ForMember(dest => dest.NombrePlanDTO, opt => opt.MapFrom(src => src.NombrePlan))
            .ForMember(dest => dest.CiudadResidenciaDTO, opt => opt.MapFrom(src => src.CiudadResidencia))
            .ForMember(dest => dest.DireccionResidenciaDTO, opt => opt.MapFrom(src => src.DireccionResidencia))
            .ForMember(dest => dest.PlacaAutomotorDTO, opt => opt.MapFrom(src => src.PlacaAutomotor))
            .ForMember(dest => dest.ModeloAutomotorDTO, opt => opt.MapFrom(src => src.ModeloAutomotor))
            .ForMember(dest => dest.VehiculoTieneInspeccionDTO, opt => opt.MapFrom(src => src.VehiculoTieneInspeccion))
            .ForMember(dest => dest.CoberturasDTO, opt => opt.MapFrom(src => src.Coberturas));


        CreateMap<PolizaDTO, Poliza>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdDTO))
            .ForMember(dest => dest.NumeroPoliza, opt => opt.MapFrom(src => src.NumeroPolizaDTO))
            .ForMember(dest => dest.NombreCliente, opt => opt.MapFrom(src => src.NombreClienteDTO))
            .ForMember(dest => dest.IdentificacionCliente, opt => opt.MapFrom(src => src.IdentificacionClienteDTO))
            .ForMember(dest => dest.FechaNacimientoCliente, opt => opt.MapFrom(src => src.FechaNacimientoClienteDTO))
            .ForMember(dest => dest.FechaInicioPoliza, opt => opt.MapFrom(src => src.FechaInicioPolizaDTO))
            .ForMember(dest => dest.FechaFinPoliza, opt => opt.MapFrom(src => src.FechaFinPolizaDTO))
            .ForMember(dest => dest.ValorMaximoCubierto, opt => opt.MapFrom(src => src.ValorMaximoCubiertoDTO))
            .ForMember(dest => dest.NombrePlan, opt => opt.MapFrom(src => src.NombrePlanDTO))
            .ForMember(dest => dest.CiudadResidencia, opt => opt.MapFrom(src => src.CiudadResidenciaDTO))
            .ForMember(dest => dest.DireccionResidencia, opt => opt.MapFrom(src => src.DireccionResidenciaDTO))
            .ForMember(dest => dest.PlacaAutomotor, opt => opt.MapFrom(src => src.PlacaAutomotorDTO))
            .ForMember(dest => dest.ModeloAutomotor, opt => opt.MapFrom(src => src.ModeloAutomotorDTO))
            .ForMember(dest => dest.VehiculoTieneInspeccion, opt => opt.MapFrom(src => src.VehiculoTieneInspeccionDTO));


        CreateMap<Cobertura, CoberturaDTO>()
            .ForMember(dest => dest.IdDTO, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NombreDTO, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.DescripcionDTO, opt => opt.MapFrom(src => src.Descripcion))
            .ForMember(dest => dest.MontoCubiertoDTO, opt => opt.MapFrom(src => src.MontoCubierto))
            .ForMember(dest => dest.PolizaIdDTO, opt => opt.MapFrom(src => src.PolizaId));

        CreateMap<CoberturaDTO, Cobertura>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdDTO))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.NombreDTO))
            .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.DescripcionDTO))
            .ForMember(dest => dest.MontoCubierto, opt => opt.MapFrom(src => src.MontoCubiertoDTO))
            .ForMember(dest => dest.PolizaId, opt => opt.MapFrom(src => src.PolizaIdDTO));
    }
}
