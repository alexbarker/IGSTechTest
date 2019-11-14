using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGSTechTest.Contracts.V1.Requests
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
