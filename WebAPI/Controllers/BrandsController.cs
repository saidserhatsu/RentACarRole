using Business.Abstract;
using Business.Concrete;
using Business.Requests.BrandRequest;
using Business.Responses.BrandResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;
    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;


    }
    [HttpPost]
    public AddBrandResponse Add(AddBrandRequest addBrandRequest)
    {
        AddBrandResponse brandResponse = _brandService.Add(addBrandRequest);
        return brandResponse;
    }
    [HttpGet]
    public GetListBrandResponse GetList([FromQuery] GetListBrandRequest getListBrandRequest)
    {
        GetListBrandResponse brandlist = _brandService.GetList(getListBrandRequest);
        return brandlist;
    }


    [HttpGet("{id}")]
    public GetByIdBrandResponse GetById(int id)
    {
        GetByIdBrandResponse brandResponse = _brandService.GetById(id);
        return brandResponse;
    }
    [HttpPut("{id}")]
    public UpdateBrandResponse Add(UpdateBrandRequest updateBrandRequest, int id)
    {
        UpdateBrandResponse brandResponse = _brandService.Update(id, updateBrandRequest);
        return brandResponse;
    }



    [HttpDelete("{id}")]
    public DeleteBrandResponse Delete(int id)
    {
        DeleteBrandResponse brandResponse = _brandService.Delete(id);
        return brandResponse;
    }

}

