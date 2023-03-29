using SeguroAutoAPI.DataAccess.Models;

namespace SeguroAutoAPI.Domain.Contracts
{
    public interface IPolizaDomainService
    {
        Poliza GetPoliza(string? placa, string? numeroPoliza);
        string PostPoliza(Poliza poliza);
        Task<Poliza> GetPolizaById(string polizaId);
        Task<IEnumerable<Poliza>> GetAllPolizas();
        Task<bool> UpdatePoliza(Poliza poliza);
        Task<bool> DeletePoliza(string idPoliza);
    }
}
