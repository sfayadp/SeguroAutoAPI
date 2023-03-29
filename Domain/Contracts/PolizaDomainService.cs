using Microsoft.EntityFrameworkCore;
using SeguroAutoAPI.DataAccess.Context;
using SeguroAutoAPI.DataAccess.Models;
using SeguroAutoAPI.DataAccess.Repository.Contracts;

namespace SeguroAutoAPI.Domain.Contracts
{
    public class PolizaDomainService : IPolizaDomainService
    {
        private readonly SeguroAutoContext _context;
        private readonly IRepository<Poliza> _polizaRepository;

        public PolizaDomainService(SeguroAutoContext context,
            IRepository<Poliza> polizaRepository)
        {
            _context = context;
            _polizaRepository = polizaRepository;
        }

        public Poliza GetPoliza(string? placa, string? numeroPoliza)
        {
            var poliza = _context.Polizas.Include(x => x.Coberturas)
                    .FirstOrDefault(p => p.PlacaAutomotor == placa || p.NumeroPoliza == numeroPoliza);

            return poliza;
        }

        public string PostPoliza(Poliza poliza)
        {
            _context.Polizas.Add(poliza);
            if (poliza != null) 
            { 
                _context.SaveChanges();
                return "Se guardo una poliza";
            }
            else
            {
                return "No se pudo guardar una poliza";
            }
        }

        /*Implementacion del patron repository*/
        public async Task<Poliza> GetPolizaById(string polizaId)
        {
            Guid polizaIdGuid = Guid.Parse(polizaId);
            return await _polizaRepository.GetByIdAsync(polizaIdGuid);
        }

        public async Task<IEnumerable<Poliza>> GetAllPolizas()
        {
            return await _polizaRepository.GetAllAsync();
        }

        public async Task<bool> UpdatePoliza(Poliza poliza)
        {
            return await _polizaRepository.UpdateAsync(poliza);
        }

        public Task<bool> DeletePoliza(string idPoliza)
        {
            Guid polizaIdGuid = Guid.Parse(idPoliza);
            return _polizaRepository.DeleteAsync(polizaIdGuid);
        }
    }
}
