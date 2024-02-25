using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : Entity<int>
    {
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public Model model { get; set; }
        public short ModelYear { get; set; }
        public int Kilometer { get; set; }
        public string CarState { get; set; }
        public string Plate { get; set; }






    }
}
