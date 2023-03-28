using SeguroAutoAPI.DataAccess.Models;
using SeguroAutoAPI.DTO;

namespace SeguroAutoAPI.Domain.Contracts
{
    public interface IPolizaDomainService
    {
        Poliza GetPoliza(string? placa, string? numeroPoliza);
        string PostPoliza(Poliza poliza);
    }
}
