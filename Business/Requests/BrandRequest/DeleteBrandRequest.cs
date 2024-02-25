using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.BrandRequest
{
    public class DeleteBrandRequest
    {
        public string Name { get; set; }

        public DeleteBrandRequest(string name)
        {
            Name = name;
        }
    }
}
