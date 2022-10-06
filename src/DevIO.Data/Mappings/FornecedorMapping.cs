using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DevIO.Business.Models;

namespace DevIO.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            // 1 : 1 => Fornecedor : Endereco
            builder.HasOne(f => f.Endereco).WithOne(f => f.Fornecedor);

            // 1 : N => Fornecedor : Produto
            builder.HasMany(f => f.Produtos).WithOne(f => f.Fornecedor).HasForeignKey(f => f.FornecedorId);
            //builder.HasMany(f => f.Produtos).WithOne(p => p.Fornecedor).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Fornecedores");
        }
    }
}
