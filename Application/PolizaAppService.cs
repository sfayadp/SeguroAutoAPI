﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeguroAutoAPI.Application.Contracts;
using SeguroAutoAPI.DataAccess.Context;
using SeguroAutoAPI.DataAccess.Models;
using SeguroAutoAPI.Domain.Contracts;
using SeguroAutoAPI.DTO;

namespace SeguroAutoAPI.Application
{
    public class PolizaAppService : IPolizaAppService
    {
        private readonly IPolizaDomainService _polizaDomainService;
        private readonly IMapper _mapper;

        public PolizaAppService(IPolizaDomainService polizaDomainService,
            IMapper mapper)
        {
            _polizaDomainService = polizaDomainService;
            _mapper = mapper;
        }

        public async Task<ActionResult<PolizaDTO>> GetPoliza(string? placa, string? numeroPoliza)
        {
            try
            {
                if (string.IsNullOrEmpty(placa) && string.IsNullOrEmpty(numeroPoliza))
                {
                    return new BadRequestObjectResult("Debe proporcionar la placa o el número de póliza");
                }

                Poliza poliza =  _polizaDomainService.GetPoliza(placa, numeroPoliza);

                if (poliza == null)
                {
                    return new NotFoundObjectResult("Póliza no encontrada");
                }                

                PolizaDTO polizaDTO = _mapper.Map<PolizaDTO>(poliza);
                List<CoberturaDTO> coberturasPolizaDTO = _mapper.Map<List<CoberturaDTO>>(poliza.Coberturas);
                polizaDTO.CoberturasDTO = coberturasPolizaDTO;


                return polizaDTO;
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public async Task<ActionResult<PolizaDTO>> PostPoliza(PolizaDTO polizaDTO)
        {
            try
            {
                if (polizaDTO.FechaInicioPolizaDTO >= polizaDTO.FechaFinPolizaDTO ||
                    polizaDTO.FechaInicioPolizaDTO < DateTime.Now ||
                    polizaDTO.FechaFinPolizaDTO < DateTime.Now)
                {
                    return new BadRequestObjectResult("La fecha de inicio no puede ser mayor que la fecha de fin");
                }

                Poliza polizaAGuardar = _mapper.Map<Poliza>(polizaDTO);

                if (polizaDTO.CoberturasDTO.Count > 0)
                {
                    List<Cobertura> coberturasPoliza = _mapper.Map<List<Cobertura>>(polizaDTO.CoberturasDTO);
                    polizaAGuardar.Coberturas = coberturasPoliza;
                }

                string result = _polizaDomainService.PostPoliza(polizaAGuardar);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

    }
}
