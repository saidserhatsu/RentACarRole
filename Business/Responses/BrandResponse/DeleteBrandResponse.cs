using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.BrandResponse
{
    public class DeleteBrandResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DeletedAt { get; set; }

        public DeleteBrandResponse(int id, string name, DateTime deletedAt)
        {
            Id = id;
            Name = name;
            DeletedAt = deletedAt;
        }
    }
}
