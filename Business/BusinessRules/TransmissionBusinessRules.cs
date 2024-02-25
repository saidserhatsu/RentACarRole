using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.BusinessRules
{
    public class TransmissionBusinessRules
    {
        private readonly ITransmissionDal _transmissionDal;
        public TransmissionBusinessRules(ITransmissionDal transmissionDal)
        {
            _transmissionDal = transmissionDal;
        }
        public void CheckIfTransmissionNameAlreadyExists(string transmissionTypeName)
        {
            //check
            bool isExists = true;
            if (isExists)
            {
                throw new Exception("Transmission already exist...");
            }
        }
        public void CheckTransmissionTypeName(string transmissionType)
        {
            List<string> transmissionTypes = new() { "Automatic", "Manual" };
            bool isContain = transmissionTypes.Contains(transmissionType);
            if (!isContain)
            {
                throw new Exception("Invalid Transmission Type...");
            }

        }

        public Transmission FindTransmissionWithId(int id)
        {
            //check
            Transmission transmission = new();
            return transmission;
        }
    }
}
