using Core.Entities;


namespace Entities.Concrete
{
    public class Transmission : Entity<int>
    {
        public string TransmissionTypeName { get; set; }
        public Transmission()
        {

        }
        public Transmission(string transMissionTypeName)
        {
            this.TransmissionTypeName = transMissionTypeName;
        }
    }
}
