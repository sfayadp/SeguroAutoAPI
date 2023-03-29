using Microsoft.AspNetCore.Mvc;
using SeguroAutoAPI.DTO;

namespace SeguroAutoAPI.Application.Contracts
{
    public interface IPolizaAppService
    {
        Task<ActionResult<PolizaDTO>> GetPoliza(string? placa, string? numeroPoliza);
        Task<ActionResult<PolizaDTO>> PostPoliza(PolizaDTO polizaDTO);
        Task<ActionResult<IEnumerable<PolizaDTO>>> GetAllPolizas();
        Task<ActionResult<PolizaDTO>> GetPolizaById(string idPoliza);
        Task<ActionResult<PolizaDTO>> UpdatePoliza(PolizaDTO polizaDTO);
        Task<ActionResult<PolizaDTO>> DeletePoliza(string idPoliza);
    }
}
