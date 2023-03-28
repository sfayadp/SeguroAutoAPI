using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeguroAutoAPI.Application.Contracts;

using SeguroAutoAPI.DTO;

namespace SeguroAutoAPI.Controllers
{
    // Controllers/PolizasController.cs
    [ApiController]
    [Route("[controller]")]
    public class PolizasController : ControllerBase
    {
        private readonly IPolizaAppService _polizaAppService;
        
        public PolizasController(IPolizaAppService polizaAppService)
        {
            _polizaAppService = polizaAppService;
        }

        // GET: api/Polizas?placa=xyz&numeroPoliza=123
        [HttpGet]
        [Authorize]
        [Route(nameof(PolizasController.GetPoliza))]
        public async Task<ActionResult<PolizaDTO>> GetPoliza(string? placa, string? numeroPoliza)
        {
            return await _polizaAppService.GetPoliza(placa, numeroPoliza);
        }

        // POST: api/Polizas
        [HttpPost]
        [Authorize]
        [Route(nameof(PolizasController.PostPoliza))]
        public async Task<ActionResult<PolizaDTO>> PostPoliza(PolizaDTO polizaDTO)
        {
            return await _polizaAppService.PostPoliza(polizaDTO);
        }
    }

}
