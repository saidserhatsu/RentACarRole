using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.BrandRequest
{
    public class UpdateBrandRequest
    {
        public string Name { get; set; }

        public UpdateBrandRequest(string name)
        {
            Name = name;
        }
    }
}
