using Business.Requests.FuelRequest;
using Business.Responses.FuelResponse;


namespace Business.Abstract
{
    public interface IFuelService
    {
        public AddFuelResponse Add(AddFuelRequest addFuelRequest);
        public IList<GetListFuelResponse> GetList();
        public GetByIdFuelResponse GetById(int id);
        public UpdateFuelResponse Update(int id, UpdateFuelRequest fuelRequest);
        public DeleteFuelResponse Delete(int id);

    }
}
