using EcoDrop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoDrop.Infrastructure.Db
{
    public class EcoDropOracleContext : DbContext
    {
        public EcoDropOracleContext(DbContextOptions<EcoDropOracleContext> options) : base(options) { }

        public DbSet<RecyclingPoint> RecyclingPoints => Set<RecyclingPoint>();
        public DbSet<MaterialType> MaterialTypes => Set<MaterialType>();
        public DbSet<RecyclingPointMaterialType> RecyclingPointMaterials => Set<RecyclingPointMaterialType>();
        public DbSet<OpeningHour> OpeningHours => Set<OpeningHour>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
            modelBuilder.Entity<RecyclingPoint>().ToTable("RM555306_RECYCLINGPOINTS");
            modelBuilder.Entity<MaterialType>().ToTable("RM555306_MATERIALTYPES");
            modelBuilder.Entity<OpeningHour>().ToTable("RM555306_OPENINGHOURS");
            modelBuilder.Entity<RecyclingPointMaterialType>().ToTable("RM555306_RPMATERIALTYPES");

            
            modelBuilder.Entity<RecyclingPointMaterialType>()
                .HasKey(x => new { x.RecyclingPointId, x.MaterialTypeId });

            modelBuilder.Entity<RecyclingPointMaterialType>()
                .HasOne(x => x.RecyclingPoint)
                .WithMany(p => p.Materials)
                .HasForeignKey(x => x.RecyclingPointId);

            modelBuilder.Entity<RecyclingPointMaterialType>()
                .HasOne(x => x.MaterialType)
                .WithMany(m => m.RecyclingPoints)
                .HasForeignKey(x => x.MaterialTypeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
