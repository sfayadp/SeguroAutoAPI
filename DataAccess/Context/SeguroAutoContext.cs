using Microsoft.EntityFrameworkCore;
using SeguroAutoAPI.DataAccess.Models;

namespace SeguroAutoAPI.DataAccess.Context
{
    // SeguroAutoContext.cs
    public class SeguroAutoContext : DbContext
    {
        public SeguroAutoContext(DbContextOptions<SeguroAutoContext> options) : base(options)
        {
        }

        public DbSet<Poliza> Polizas { get; set; }
        public DbSet<Cobertura> Coberturas { get; set; }
    }

}