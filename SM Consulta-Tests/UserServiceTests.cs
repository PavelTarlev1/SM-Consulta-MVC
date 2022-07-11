using Auth_Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SM_Consulta_MVC;
using SM_Consulta_MVC.Data;
using SM_Consulta_MVC.Models.Entity;
using SM_Consulta_MVC.service;

namespace SM_Consulta_Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
        private readonly IConfiguration _configuration = Substitute.For<IConfiguration>();

        public UserServiceTests()
        {
            Startup _startup = new Startup(_configuration);
            this._userService = new UserService(
                _userRepository,
                _startup._incomeTax,
                _startup._healt_social_innsurance_tax,
                _startup._maximumInsuranceIncome,
                _startup._minimumInsuranceIncome);
        }

        [TestMethod]
        public void GIVEN_ValidInput_SHOULD_FillParametersCollection_Under1000()
        {
            RegisterModel testModel = new RegisterModel();
            UserEntity userEntity = new UserEntity();
            testModel.Name = "Pesho";
            testModel.Salary = 900;
            userEntity.Name = "Pesho";
            userEntity.Salary = 900;
            var user = this._userService.Taxsation(testModel);
            Assert.AreEqual(userEntity.Name ,user.Name);
            Assert.AreEqual(userEntity.Salary, user.Salary);
            Assert.AreEqual(0, user.IncomeTax);
            Assert.AreEqual(0, user.HealthSocialInsurance);
        }

        [TestMethod]
        public void CreateCornerCase_GIVEN_ValidInput_SHOULD_FillParametersCollection_At1000()
        {
            RegisterModel testModel = new RegisterModel();
            UserEntity userEntity = new UserEntity();
            testModel.Name = "Pesho";
            testModel.Salary = 1000;
            userEntity.Name = "Pesho";
            userEntity.Salary = 1000;
            var user = this._userService.Taxsation(testModel);
            Assert.AreEqual(userEntity.Name, user.Name);
            Assert.AreEqual(userEntity.Salary, user.Salary);
            Assert.AreEqual(0, user.IncomeTax);
            Assert.AreEqual(0, user.HealthSocialInsurance);
        }

        [TestMethod]
        public void CreateCornerCase_GIVEN_ValidInput_SHOULD_FillParametersCollection_At1001()
        {
            RegisterModel testModel = new RegisterModel();
            UserEntity userEntity = new UserEntity();
            testModel.Name = "Pesho";
            testModel.Salary = 1001;
            userEntity.Name = "Pesho";
            userEntity.Salary = 1001;
            var user = this._userService.Taxsation(testModel);
            Assert.AreEqual(userEntity.Name, user.Name);
            Assert.AreEqual(userEntity.Salary, user.Salary);
            Assert.AreEqual(100, user.IncomeTax);
            Assert.AreEqual(150, user.HealthSocialInsurance);
        }

        [TestMethod]
        public void CreateCornerCase_GIVEN_ValidInput_SHOULD_FillParametersCollection_At3000()
        {
            RegisterModel testModel = new RegisterModel();
            UserEntity userEntity = new UserEntity();
            testModel.Name = "Pesho";
            testModel.Salary = 3000;
            userEntity.Name = "Pesho";
            userEntity.Salary = 3000;
            var user = this._userService.Taxsation(testModel);
            Assert.AreEqual(userEntity.Name, user.Name);
            Assert.AreEqual(userEntity.Salary, user.Salary);
            Assert.AreEqual(300, user.IncomeTax);
            Assert.AreEqual(450, user.HealthSocialInsurance);
            Assert.AreEqual(750, user.TotalTaxes);
            Assert.AreEqual(2250, user.NetSaLary);
        }

        [TestMethod]
        public void CreateCornerCase_GIVEN_ValidInput_SHOULD_FillParametersCollection_At5000()
        {
            RegisterModel testModel = new RegisterModel();
            UserEntity userEntity = new UserEntity();
            testModel.Name = "Pesho";
            testModel.Salary = 5000;
            userEntity.Name = "Pesho";
            userEntity.Salary = 5000;
            var user = this._userService.Taxsation(testModel);
            Assert.AreEqual(userEntity.Name, user.Name);
            Assert.AreEqual(userEntity.Salary, user.Salary);
            Assert.AreEqual(300, user.IncomeTax);
            Assert.AreEqual(450, user.HealthSocialInsurance);
            Assert.AreEqual(750, user.TotalTaxes);
            Assert.AreEqual(4250, user.NetSaLary);
        }

        [TestMethod]
        public void CreateCornerCase_GIVEN_ValidInput_SHOULD_FillParametersCollection_At0()
        {
            RegisterModel testModel = new RegisterModel();
            UserEntity userEntity = new UserEntity();
            testModel.Name = "Pesho";
            testModel.Salary = 0;
            userEntity.Name = "Pesho";
            userEntity.Salary = 0;
            var user = this._userService.Taxsation(testModel);
            Assert.AreEqual(userEntity.Name, user.Name);
            Assert.AreEqual(userEntity.Salary, user.Salary);
            Assert.AreEqual(0, user.IncomeTax);
            Assert.AreEqual(0, user.HealthSocialInsurance);
            Assert.AreEqual(0, user.TotalTaxes);
            Assert.AreEqual(0, user.NetSaLary);
        }
    }
}
