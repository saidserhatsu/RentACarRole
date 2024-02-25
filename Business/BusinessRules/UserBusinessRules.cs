using Core.CrossCuttingConcerns.Exceptions;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business
{
    public class UserBusinessRules
    {
        private readonly IUserDal _userDal;
        public UserBusinessRules(IUserDal userDal)
        {
            _userDal = userDal;
        }
    

        public User FindUserWithId(int id)
        {
            User user = _userDal.Get(predicate: e => e.Id == id);

            return user;
        }
        public void CheckIfUserExists(User? user)
        {

            if (user == null)
            {
                throw new NotFoundException("User not found...");
            }
        }

   
    }
}