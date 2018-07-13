using GeaWeb.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.Cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Empresa");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Cnpj).HasColumnName("Cnpj");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Id).HasColumnName("Id");
        }
    }
}
