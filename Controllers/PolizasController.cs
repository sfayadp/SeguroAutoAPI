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

        [HttpGet]
        [Authorize]
        [Route(nameof(PolizasController.GetAllPolizas))]
        public async Task<ActionResult<IEnumerable<PolizaDTO>>> GetAllPolizas()
        {
            return await _polizaAppService.GetAllPolizas();
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(PolizasController.GetPolizaById))]
        public async Task<ActionResult<PolizaDTO>> GetPolizaById(string id)
        {
            return await _polizaAppService.GetPolizaById(id);
        }

        [HttpPut]
        [Authorize]
        [Route(nameof(PolizasController.UpdatePoliza))]
        public async Task<ActionResult<PolizaDTO>> UpdatePoliza(PolizaDTO polizaDTO)
        {
            return await _polizaAppService.UpdatePoliza(polizaDTO);
        }

        [HttpDelete]
        [Authorize]
        [Route(nameof(PolizasController.DeletePoliza))]
        public async Task<ActionResult<PolizaDTO>> DeletePoliza(string id)
        {
            return await _polizaAppService.DeletePoliza(id);
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
