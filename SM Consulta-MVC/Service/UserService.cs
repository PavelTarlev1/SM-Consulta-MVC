using System.Collections.Generic;
using Auth_Api.Models;
using SM_Consulta_MVC.Data;
using SM_Consulta_MVC.Models.Entity;

namespace SM_Consulta_MVC.service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly double _incomeTax;
        private readonly double _healt_social_innsurance_tax;
        private readonly int _maximumInsuranceIncome;
        private readonly int _minimumInsuranceIncome;

        public UserService(IUserRepository userRepository,
            double incomeTax,
            double healt_social_innsurance_tax,
            int maximumInsuranceIncome, int minimumInsuranceIncome)
        {
            this._userRepository = userRepository;
            this._incomeTax = incomeTax;
            this._healt_social_innsurance_tax = healt_social_innsurance_tax;
            this._maximumInsuranceIncome = maximumInsuranceIncome;
            this._minimumInsuranceIncome = minimumInsuranceIncome;
        }

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public void AddUser(RegisterModel model)
        {
            UserEntity user = Taxsation(model);
            this._userRepository.AddUserToRep(user);
        }

        public List<UserEntity> PullUsers()
        {
            return this._userRepository.PullAllUsers();
        }

        public UserEntity Taxsation(RegisterModel model)
        {
            var user = new UserEntity
            {
                Name = model.Name,
                Salary = model.Salary,
                IncomeTax = 0,
                HealthSocialInsurance = 0
            };

            if (model.Salary > _minimumInsuranceIncome && model.Salary < _maximumInsuranceIncome)
            {
                user.IncomeTax = this.IncomeТax(model.Salary);
                user.HealthSocialInsurance = this.HealthSocialInsurance(model.Salary);
            }

            if (model.Salary >= _maximumInsuranceIncome)
            {
                user.IncomeTax = this.IncomeТax(_maximumInsuranceIncome);
                user.HealthSocialInsurance = this.HealthSocialInsurance(_maximumInsuranceIncome);
            }

            user.TotalTaxes = user.IncomeTax + user.HealthSocialInsurance;
            user.NetSaLary = user.Salary - user.TotalTaxes;
            return user;
        }

        private int IncomeТax(int salary)
        {
            return (int)(salary * this._incomeTax);
        }

        private int HealthSocialInsurance(int salary)
        {
            return (int)(salary * this._healt_social_innsurance_tax);
        }
    }
}


