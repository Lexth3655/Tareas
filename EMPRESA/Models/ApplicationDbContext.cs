using Microsoft.EntityFrameworkCore;

namespace EMPRESA.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<EmpleadosTipos> EmpleadosTipos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empleado>(entity => entity.ToTable("Empleados"));
            modelBuilder.Entity<EmpleadosTipos>(entity => entity.ToTable("EmpleadosTipos"));
        }



    }
}
