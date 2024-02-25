using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.BrandRequest
{
    public class GetByIdBrandRequest
    {
        public string Name { get; set; }

        public GetByIdBrandRequest(string name)
        {
            Name = name;
        }
    }
}
