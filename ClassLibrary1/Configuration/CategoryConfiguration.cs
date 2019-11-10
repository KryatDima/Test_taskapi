using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_task.Data.Entities;

namespace Test_task.Data.Configuration
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void ConfigureSpecific(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
        }
    }
}
