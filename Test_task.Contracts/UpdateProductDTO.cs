using System;
using System.Collections.Generic;
using System.Text;

namespace Test_task.Contracts
{
    public class UpdateProductDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long CategoryId { get; set; }
    }
}
