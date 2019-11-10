﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Test_task.Data.Interfaces;

namespace Test_task.Data.Configuration
{
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity: class, IEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
            ConfigureSpecific(builder);
        }

        public abstract void ConfigureSpecific(EntityTypeBuilder<TEntity> builder);
    }
}
