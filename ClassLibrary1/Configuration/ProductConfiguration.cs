using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_task.Data.Entities;

namespace Test_task.Data.Configuration
{
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public override void ConfigureSpecific(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasOne(x => x.Category);
        }
    }
}
