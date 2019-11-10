using System;
using System.Collections.Generic;
using System.Text;

namespace Test_task.Contracts
{
    public class CreateProductDTO
    {
        public string Title { get; set; }
        public long CategoryId { get; set; }
        //public CategoryDTO CategoryDTO { get; set; }
    }
}
