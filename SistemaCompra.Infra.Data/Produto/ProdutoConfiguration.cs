﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoAgg.Produto>
    {
        public void Configure(EntityTypeBuilder<ProdutoAgg.Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(c => c.Preco, b => b.Property("Value").HasColumnName("Preco"));
            builder.ToTable("Produto");
        }
    }
}
