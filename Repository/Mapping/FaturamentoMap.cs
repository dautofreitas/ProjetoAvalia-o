using GeaWeb.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class FaturamentoMap : EntityTypeConfiguration<Faturamento>
    {
        public FaturamentoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Faturamento");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DataCompetencia).HasColumnName("DataCompetencia");
            this.Property(t => t.DataPagamento).HasColumnName("DataPagamento");
            this.Property(t => t.ValorCompetencia).HasColumnName("ValorCompetencia");

            // Relationships
            this.HasRequired(t => t.Empresa)
                .WithMany(t => t.Faturamentos)
                .HasForeignKey(d => d.EmpresaId);

        }
    }
}
