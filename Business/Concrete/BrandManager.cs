using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.BrandRequest;
using Business.Responses.BrandResponse;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;
    private readonly BrandBusinessRules _brandBusinessRules;
    private readonly IMapper _mapper;
    public BrandManager(IBrandDal brandDal, BrandBusinessRules brandBusinessRules, IMapper mapper)
    {
        _brandDal = brandDal;
        _brandBusinessRules = brandBusinessRules;
        _mapper = mapper;
    }

    public AddBrandResponse Add(AddBrandRequest brandRequest)
    {
        _brandBusinessRules.CheckIfBrandNameAlreadyExists(brandRequest.Name);

        Brand brandToAdd = _mapper.Map<Brand>(brandRequest);
        _brandDal.Add(brandToAdd);
        AddBrandResponse brandResponse = _mapper.Map<AddBrandResponse>(brandToAdd);
        return brandResponse;
    }

  /*  public IList<GetListBrandResponse> GetList()
    {
        IList<Brand> brandList = _brandDal.GetList();
        List<GetListBrandResponse> brandResponseList = new List<GetListBrandResponse>();
        foreach (Brand brand in brandList)
        {
            brandResponseList.Add(_mapper.Map<GetListBrandResponse>(brand));

        }
        return brandResponseList;
    }*/

    public GetByIdBrandResponse GetById(int id)
    {
        Brand brand = _brandBusinessRules.FindBrandWithId(id);
        if (brand == null)
        {
            throw new Exception("Brand is not exists...");
        }
        GetByIdBrandResponse brandResponse = _mapper.Map<GetByIdBrandResponse>(brand);
        return brandResponse;
    }

    public UpdateBrandResponse Update(int id, UpdateBrandRequest brandRequest)
    {
        Brand brand = _brandBusinessRules.FindBrandWithId(id);
        brand.Name = brandRequest.Name;
        brand.UpdateAt = DateTime.Now;
        UpdateBrandResponse brandResponse = _mapper.Map<UpdateBrandResponse>(brand);
        return brandResponse;
    }

    public DeleteBrandResponse Delete(int id)
    {
        Brand brand = _brandBusinessRules.FindBrandWithId(id);
        brand.DeletedAt = DateTime.Now;
        DeleteBrandResponse brandResponse = _mapper.Map<DeleteBrandResponse>(brand);
        return brandResponse;
    }

    public GetListBrandResponse GetList(GetListBrandRequest request)
    {

        IList<Brand> list = new List<Brand>();
        GetListBrandResponse getListBrandResponse = _mapper.Map<GetListBrandResponse>(list);
        return getListBrandResponse;
    }
}

