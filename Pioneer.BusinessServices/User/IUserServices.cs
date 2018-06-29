using Pioneer.BusinessEntities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pioneer.BusinessServices.User
{
    public interface IUserServices
    {
        void DynameTestService();
       CustomerAPI Authenticate(string userName, string password);
        // CustomerAPI ValidateUser(string userName, string password);
        IEnumerable<CustomerAPI> GetAllUsers();
        UserEntity GetUserById(string userId, string userType);
        Guid CreateUser(CustomerAPI productEntity);
        //bool UpdateUser(Guid userId, CustomerAPI userEntity);
        // bool DeleteUser(Guid userId);
    }
}
