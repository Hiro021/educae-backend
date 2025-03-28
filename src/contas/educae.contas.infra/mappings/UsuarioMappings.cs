using educae.contas.domain;
using educae.contas.domain.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace educae.contas.infra.mappings
{
    public class UsuarioMappings : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(200).IsRequired();

            builder.Property(c => c.TipoUsuario).HasColumnName("TipoUsuario").IsRequired();
            
            builder.OwnsOne(c => c.Login, login =>
            {
                login.Property(c => c.Hash).HasColumnName("LoginHash");

                login.OwnsOne(c => c.Email,
                    email => { email.Property(x => x.Endereco).HasMaxLength(256).HasColumnName("Email"); });

                login.OwnsOne(c => c.Senha,
                    senha => { senha.Property(x => x.Valor).HasMaxLength(1000).HasColumnName("Senha"); });
            });
        }
    }
}