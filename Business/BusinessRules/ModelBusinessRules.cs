using Business.Requests.ModelRequest;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules
{
    public class ModelBusinessRules
    {
        private readonly IModelDal _modelDal;
        public ModelBusinessRules(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        public void CheckIfModelNameAlreadyExists(AddModelRequest addModelRequest)
        {
            Model model = _modelDal.Get(predicate : model => model.Name == addModelRequest.Name);
            if (model != null)
            {
                throw new BusinessException("Model already exist...");
            }
        }

        public Model FindModelWithId(int id)
        {
            Model model = _modelDal.Get(predicate: e => e.Id == id);

            return model;
        }
        public void CheckIfModelExists(Model? model)
        {
            
            if (model == null)
            {
                throw new NotFoundException("Model not found...");
            }
        }

        public void CheckIfModelYearShouldBeInLast20Years(short year)
        {
            if(year < DateTime.UtcNow.AddYears(-20).Year)
            {
                throw new BusinessException("Model Year should be in last 20 years.");
            }
        }
    }
}
