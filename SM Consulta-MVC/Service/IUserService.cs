using Auth_Api.Models;
using SM_Consulta_MVC.Models.Entity;
using System.Collections.Generic;

namespace SM_Consulta_MVC.service
{
    public interface IUserService
    {
        void AddUser(RegisterModel model);

        List<UserEntity> PullUsers();
    }
}