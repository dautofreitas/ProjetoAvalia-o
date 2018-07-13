using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GeaWeb.Models;
using Repository.Models.Mapping;

namespace Data.Models
{
    public partial class GeaContext : DbContext
    {
        static GeaContext()
        {
            Database.SetInitializer<GeaContext>(null);
        }

        public GeaContext()
            : base("Name=GeaContext")
        {
        }

        public DbSet<Carro> Carroes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Faturamento> Faturamentoes { get; set; }
        public DbSet<Operador> Operadors { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<RegistroDeFluxo> RegistroDeFluxoes { get; set; }     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarroMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new FaturamentoMap());
            modelBuilder.Configurations.Add(new OperadorMap());
            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new RegistroDeFluxoMap());          
        }
    }
}
