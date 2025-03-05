using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Entities;

namespace UsuarioApp.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();


            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(40)
                .IsRequired();


            builder.Ignore(u => u.AcessToken);

        }
    }
}
