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
        
        public GeaContext(string connectionName)
            : base(connectionName)
        {
        }
        
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

    }
}
