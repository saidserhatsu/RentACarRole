using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.BrandResponse
{
    public class UpdateBrandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateAt { get; set; }

        public UpdateBrandResponse(int id, string name, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            UpdateAt = updatedAt;
        }
    }
}
