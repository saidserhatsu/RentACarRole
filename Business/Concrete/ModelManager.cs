using AutoMapper;
using Azure.Core;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.Model;
using Business.Requests.ModelRequest;
using Business.Responses.ModelResponse;
using Core.CrossCuttingConcerns.NewFolder.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        private readonly IModelDal _modelDal;
        private readonly ModelBusinessRules _modelBusinessRules;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public ModelManager(IModelDal modeldal, ModelBusinessRules modelBusinessRules, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            this._modelDal = modeldal;
            this._modelBusinessRules = modelBusinessRules;
            this._mapper = mapper;
            this._contextAccessor = contextAccessor;
        }

        public AddModelResponse Add(AddModelRequest modelRequest)
        {
            var userRoleClaim = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Role");
            if (!_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                throw new Exception("You must Login!");
            }
            if(!(userRoleClaim.Value == "2"))
            {
                throw new Exception("Invalid!!!");
            }
          
            ValidationTool.Validate(new AddModelRequestValidator(), modelRequest);
            _modelBusinessRules.CheckIfModelNameAlreadyExists(modelRequest);
            _modelBusinessRules.CheckIfModelYearShouldBeInLast20Years(modelRequest.Year);
            Model model = _mapper.Map<Model>(modelRequest);
            _modelDal.Add(model);
            AddModelResponse modelResponse = _mapper.Map<AddModelResponse>(model);
            return modelResponse;
        }
        public GetListModelResponse GetList(GetListModelRequest request)
        {
            IList<Model> modelList = _modelDal.GetList(
                  predicate: model =>
                  (request.BrandId == null || model.BrandId == request.BrandId)
                   && (request.FuelId == null || model.FuelId == request.FuelId)
                   && (
                  request.TransmissionId == null
                    || model.TransmissionId == request.TransmissionId
                    ) && ( model.DeletedAt == null)
              );

            // mapping & response
            var response = _mapper.Map<GetListModelResponse>(modelList);
            return response;
        }

        public GetByIdModelResponse GetById(GetByIdModelRequest getByIdModelRequest)
        {
            Model? model = _modelBusinessRules.FindModelWithId(getByIdModelRequest.Id);
            _modelBusinessRules.CheckIfModelExists(model);
            GetByIdModelResponse modelResponse = _mapper.Map<GetByIdModelResponse>(model);
            return modelResponse;
        }

        public UpdateModelResponse Update(UpdateModelRequest modelRequest)
        {
            Model model = _modelBusinessRules.FindModelWithId(modelRequest.Id);
            _modelBusinessRules.CheckIfModelExists(model);
            _modelBusinessRules.CheckIfModelYearShouldBeInLast20Years(modelRequest.Year);
            model = _mapper.Map(modelRequest,model);
            Model updatedModel=_modelDal.Update(model);
            UpdateModelResponse modelResponse = _mapper.Map<UpdateModelResponse>(updatedModel);
            return modelResponse;
        }

        public DeleteModelResponse Delete(DeleteModelRequest deleteModelRequest,bool isSoftDelete = true)
        {
            Model? model = _modelBusinessRules.FindModelWithId(deleteModelRequest.Id);
            _modelBusinessRules.CheckIfModelExists(model);
            Model deletedModel=_modelDal.Delete(model!);
            DeleteModelResponse modelResponse = _mapper.Map<DeleteModelResponse>(deletedModel);
            return modelResponse;
        }

        
    }
}
