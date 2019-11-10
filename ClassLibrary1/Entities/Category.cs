using System;
using System.Collections.Generic;
using System.Text;
using Test_task.Data.Interfaces;

namespace Test_task.Data.Entities
{
    public class Category : IEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
