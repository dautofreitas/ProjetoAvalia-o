using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Data.Mapping;
using GeaWebMVC.Models;
using Repository.Models.Mapping;

namespace Data
{
    public class GeaContext : DbContext
    {
        
        public GeaContext()
            : base("Name=GeaContext")
        {
        }
        /*public DbSet<Carro> Carros { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Faturamento> Faturamentos { get; set; }
        public DbSet<Operador> Operadores { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<RegistroDeFluxo> RegistroDeFluxos { get; set; }     
        */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarroMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new FaturamentoMap());
            modelBuilder.Configurations.Add(new OperadorMap());
            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new RegistroDeFluxoMap());
            modelBuilder.Ignore<RegistroDeFluxoWihtCarro>();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<GeaWebMVC.Models.RegistroDeFluxoWihtCarro> RegistroDeFluxoWihtCarroes { get; set; }
    }
}
