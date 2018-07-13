using GeaWeb.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class OperadorMap : EntityTypeConfiguration<Operador>
    {
        public OperadorMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.Cpf)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.Login)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Operador");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Cpf).HasColumnName("Cpf");
            this.Property(t => t.Login).HasColumnName("Login");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PerfilId).HasColumnName("PerfilId");

            // Relationships
            this.HasRequired(t => t.Empresa)
                .WithMany(t => t.Operadores)
                .HasForeignKey(d => d.EmpresaId);
            this.HasRequired(t => t.Perfil)
                .WithMany(t => t.Operadores)
                .HasForeignKey(d => d.PerfilId);

        }
    }
}
