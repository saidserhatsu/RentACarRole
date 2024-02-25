using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.BrandResponse
{
    public class GetListBrandResponse
    {
        public ICollection<BrandListItemDto> Items { get; set; }

        public GetListBrandResponse()
        {
            Items=Array.Empty<BrandListItemDto>();
        }
        public GetListBrandResponse(ICollection<BrandListItemDto> items)
        {
            this.Items=items;
        }
    }
}
