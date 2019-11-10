using System;
using System.Collections.Generic;
using System.Text;
using Test_task.Data.Interfaces;

namespace Test_task.Data.Entities
{
    public class Product : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
