using Microsoft.EntityFrameworkCore;
using SeguroAutoAPI.DataAccess.Context;
using SeguroAutoAPI.DataAccess.Models;


namespace SeguroAutoAPI.Domain.Contracts
{
    public class PolizaDomainService : IPolizaDomainService
    {
        private readonly SeguroAutoContext _context;

        public PolizaDomainService(SeguroAutoContext context)
        {
            _context = context;
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
    }
}
