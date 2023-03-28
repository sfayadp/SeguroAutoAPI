using Microsoft.AspNetCore.Mvc;
using SeguroAutoAPI.DTO;

namespace SeguroAutoAPI.Application.Contracts
{
    public interface IPolizaAppService
    {
        Task<ActionResult<PolizaDTO>> GetPoliza(string? placa, string? numeroPoliza);
        Task<ActionResult<PolizaDTO>> PostPoliza(PolizaDTO poliza);
    }
}
