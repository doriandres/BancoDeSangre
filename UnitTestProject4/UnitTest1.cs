using BancoDeSangre.Models;
using BancoDeSangre;
using BancoDeSangre.Services.ManagerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using BancoDeSangre.Services.DonationService;
using System;
using BancoDeSangre.Services.MedicalCenterService;

namespace UnitTestProject4
{
    [TestClass]
    public class DonorService
    {
        [TestMethod]
        public void Donor_add_Tests()
        {

            //Arrange 
            var donationservice = new DonationDBService();
            Donation donation = new Donation();


            // Act
            var resultado = donationservice.Equals(donation);


            // Assert
            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void Manager_Service_Tests()
        {
            //Arrange
            var managerservice = new ManagerDBService();
            Manager manager = new Manager();

            // Act

            var resultado = manager.GetType();

            // Assert
            Assert.IsFalse();
        }
        [TestMethod]
        public void Medical_Center_Test()
        {
            //Arrange
           var medicalcenter = new MedicalCenterDBService();
           MedicalCenter save = new MedicalCenter();

            //Act

          var resultado = MedicalCenter.Empty();

            //Asset
            Assert.Fail();
        }
    }
}


            
        

    



