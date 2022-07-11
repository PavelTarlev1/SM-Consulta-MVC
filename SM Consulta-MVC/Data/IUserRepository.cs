using Auth_Api.Models;
using SM_Consulta_MVC.Models.Entity;
using System.Collections.Generic;

namespace SM_Consulta_MVC.Data
{
    public interface IUserRepository
    {
        void AddUserToRep(UserEntity user);

        List<UserEntity> PullAllUsers();
    }
}