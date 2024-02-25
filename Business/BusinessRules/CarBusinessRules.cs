using Business.Abstract;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class CarBusinessRules
    {
        private readonly ICarDal _carDal;
        private readonly IModelDal _modelDal;
        public CarBusinessRules(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void CheckIfCarPlateAlreadyExists(string plate)
        {
            
            bool isExists = true;
            if (isExists)
            {
                throw new BusinessException("Car already exist...");
            }
        }

        public Car FindCarWithId(int id)
        {
            Car car =new();
            return car;
        }
        public Model FindCarWithModelId(int id)
        {
            Model model = new();
            if (model == null)
            {
                throw new BusinessException("Model is not found...");
            }
            return model;
        }
    }
}
