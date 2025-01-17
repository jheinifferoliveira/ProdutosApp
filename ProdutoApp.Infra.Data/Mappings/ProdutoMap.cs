﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoApp.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.Nome).HasColumnName("NOME").IsRequired();
            builder.Property(p => p.Preco).HasColumnName("PRECO").IsRequired().HasPrecision(18,2);
            builder.Property(p => p.Quantidade).HasColumnName("QUANTIDADE").IsRequired();
            builder.Property(p => p.FornecedorId).HasColumnName("FORNECEDOR_ID").IsRequired();

            builder.HasOne(p => p.Fornecedor)
                .WithMany(p=>p.Produtos)
                .HasForeignKey(p => p.FornecedorId);
        }
    }
}
