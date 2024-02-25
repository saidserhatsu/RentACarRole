using Business.Requests.TransmissionRequest;
using Business.Responses.TransmissionResponse;

namespace Business.Abstract
{
    public interface ITransmissionService
    {
        public AddTransmissionResponse Add(AddTransmissionRequest addTransmissionRequest);
        public IList<AddTransmissionResponse> GetList();
        public AddTransmissionResponse GetById(int id);
        public AddTransmissionResponse Update(int id, AddTransmissionRequest transmissionRequest);
        public AddTransmissionResponse Delete(int id);
    }
}
