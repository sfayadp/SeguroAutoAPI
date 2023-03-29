using SeguroAutoAPI.Application;
using SeguroAutoAPI.Application.Contracts;
using SeguroAutoAPI.DataAccess.Models;
using SeguroAutoAPI.DataAccess.Repository;
using SeguroAutoAPI.DataAccess.Repository.Contracts;
using SeguroAutoAPI.Domain.Contracts;

namespace SeguroAutoAPI.DI
{
    public static class DependencyInjection
    {
        public static void AddServices(IServiceCollection services)
        {
            #region AppServices
            services.AddScoped<IPolizaAppService, PolizaAppService>();
            services.AddScoped<IAuthService, AuthService>();
            #endregion

            #region Domain
            services.AddScoped<IPolizaDomainService, PolizaDomainService>();
            #endregion

            #region AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));
            #endregion

            #region Repository
            services.AddScoped<IRepository<Poliza>, Repository<Poliza>>();
            #endregion
        }
    }
}
