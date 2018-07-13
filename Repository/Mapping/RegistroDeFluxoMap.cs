using GeaWeb.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class RegistroDeFluxoMap : EntityTypeConfiguration<RegistroDeFluxo>
    {
        public RegistroDeFluxoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("RegistroDeFluxo");
            this.Property(t => t.FaturamentoId).HasColumnName("FaturamentoId");
            this.Property(t => t.OperadorId).HasColumnName("OperadorId");
            this.Property(t => t.CarroId).HasColumnName("CarroId");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DataHoraEntrada).HasColumnName("DataHoraEntrada");
            this.Property(t => t.DataHoraSaida).HasColumnName("DataHoraSaida");
            this.Property(t => t.ValorAPagar).HasColumnName("ValorAPagar");

            // Relationships
            this.HasRequired(t => t.Carro)
                .WithMany(t => t.RegistroDeFluxos)
                .HasForeignKey(d => d.CarroId);
            this.HasOptional(t => t.Faturamento)
                .WithMany(t => t.RegistroDeFluxos)
                .HasForeignKey(d => d.FaturamentoId);
            this.HasRequired(t => t.Operador)
                .WithMany(t => t.RegistroDeFluxos)
                .HasForeignKey(d => d.OperadorId);

        }
    }
}
