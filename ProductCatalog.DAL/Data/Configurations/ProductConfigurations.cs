
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.DAL.Data.Configurations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(P => P.Name)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(P => P.CreationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(P => P.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}
