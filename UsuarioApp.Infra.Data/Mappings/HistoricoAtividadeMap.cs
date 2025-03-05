using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Entities;

namespace UsuarioApp.Infra.Data.Mappings
{
    public class HistoricoAtividadeMap : IEntityTypeConfiguration<HistoricoAtividade>
    {
        public void Configure(EntityTypeBuilder<HistoricoAtividade> builder)
        {
            builder.ToTable("HISTORICOATIVIDADE");

            builder.HasKey(h => h.Id);


            builder.Property(h => h.Id)
                .HasColumnName("ID");

            builder.Property(h => h.DataHora)
                .HasColumnName("DATAHORA")
                .IsRequired();


            builder.Property(h => h.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(250)
                .IsRequired();


            builder.Property(h => h.UsuarioId)
                .HasColumnName("USUARIOID");


            builder.HasOne(h => h.Usuario)
                .WithMany(u => u.Historicos)
                .HasForeignKey(h => h.UsuarioId);
           
        }
    }
}
