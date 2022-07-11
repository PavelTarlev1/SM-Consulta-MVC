using Auth_Api.Data.DataAccess;
using Auth_Api.Models;
using SM_Consulta_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM_Consulta_MVC.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _repository;

        public UserRepository(UserContext context)
        {
            this._repository = context;
        }

        public List<UserEntity> PullAllUsers()
        {
            return this._repository.UserEntities.ToList();
        }

        /// <summary>
        /// Adding user to Repository.
        /// </summary>
        /// <param name="user"></param>
        public void AddUserToRep(UserEntity user)
        {
            this._repository.Add(user);
            this._repository.SaveChanges();
        }
    }
}
