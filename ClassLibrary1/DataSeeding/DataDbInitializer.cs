using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test_task.Data.Context;
using Test_task.Data.Entities;

namespace Test_task.Data.DataSeeding
{
    public class DataDbInitializer
    {
        private static readonly Category[] categories = new[]
        {
            new Category(){ Title="Fruits"},
            new Category(){ Title="Vegetables"}
        };

        public static void Seed(Test_taskDbContext context)
        {
            if (!context.Categories.Any())
                context.Categories.AddRange(categories);

            context.SaveChanges();
        }
    }
}
