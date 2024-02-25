namespace Business.Abstract
{
    public interface ICarService
    {
        public AddCarResponse Add(AddCarRequest carRequest);
        public GetListCarResponse GetList(GetListCarRequest request);
        public GetByIdCarResponse GetById(int id);
        public UpdateCarResponse Update(int id, UpdateCarRequest carRequest);
        public DeleteCarResponse Delete(int id);
    }
}
