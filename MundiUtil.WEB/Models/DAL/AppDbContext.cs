using Microsoft.EntityFrameworkCore;
using MundiUtil.WEB.Models.Entities;

namespace MundiUtil.WEB.Models.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<Insumo> insumo { get; set; }
        public DbSet<ClaseInsumo> clases { get; set; }
        
    }
}
