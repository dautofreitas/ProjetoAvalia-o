using GeaWeb.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class CarroMap : EntityTypeConfiguration<Carro>
    {
        public CarroMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Placa)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(7);

            this.Property(t => t.Marca)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Modelo)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Carro");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Placa).HasColumnName("Placa");
            this.Property(t => t.Marca).HasColumnName("Marca");
            this.Property(t => t.Modelo).HasColumnName("Modelo");
        }
    }
}
