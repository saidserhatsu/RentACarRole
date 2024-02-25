using Business.Requests.BrandRequest;
using Business.Responses.BrandResponse;
using Entities.Concrete;

namespace Business.Abstract;

public interface IBrandService
{
    public AddBrandResponse Add(AddBrandRequest brandRequest);
    public GetListBrandResponse GetList(GetListBrandRequest request);
    public GetByIdBrandResponse GetById(int id);
    public UpdateBrandResponse Update(int id, UpdateBrandRequest brandRequest);
    public DeleteBrandResponse Delete(int id);
   
}
