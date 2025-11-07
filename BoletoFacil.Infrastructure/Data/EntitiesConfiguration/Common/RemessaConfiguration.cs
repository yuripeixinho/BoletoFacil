using BoletoFacil.Domain.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoFacil.Infrastructure.Data.EntitiesConfiguration.Bancos.Itau.CNAB400;

public class RemessaConfiguration : IEntityTypeConfiguration<Remessa>
{
    public void Configure(EntityTypeBuilder<Remessa> builder)
    {
        builder.ToTable("Remessas");

        //builder.HasKey(x => x.RemessaId);

        //builder.Property(x => x.Layout)
        //       .IsRequired();

        //builder.HasOne(x => x.Header)
        //       .WithOne()
        //       .HasForeignKey<Remessa>(x => x.HeaderId)
        //       .OnDelete(DeleteBehavior.Restrict);
    }
}