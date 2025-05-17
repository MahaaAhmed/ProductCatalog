
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
    internal class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(D => D.Name)
                .IsRequired(true)
                .HasMaxLength(50);
            builder.HasMany(d => d.Products)
                .WithOne(E => E.Category)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
