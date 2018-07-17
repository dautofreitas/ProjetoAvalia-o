using GeaWebMVC.Models;
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
            this.Property(t => t.HoraEntrada).HasColumnName("HoraEntrada");
            this.Property(t => t.DataEntrada).HasColumnName("DataEntrada");
            this.Property(t => t.HoraSaida).HasColumnName("HoraSaida");            
            this.Property(t => t.DataSaida).HasColumnName("DataSaida");
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
