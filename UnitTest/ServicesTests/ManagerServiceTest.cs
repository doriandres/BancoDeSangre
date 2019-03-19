using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using BancoDeSangre.Services.ManagerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.ServicesTests
{
    [TestClass]
    public class ManagerServiceTest
    {
        [TestMethod]
        public void Create_Manager_Test()
        {
            // Arrange
            using (var dbService = new DataBaseService())
            {
                IManagerService managerService = new ManagerDBService(dbService);
                var manager = new Manager
                {
                    Email = "user@mail.com",
                    Name = "Username",
                    LastName = "Userlastname",
                    Password = "Password"
                };

                // Act
                var result = managerService.CreateManager(manager);

                // Assert
                Assert.IsTrue(result, "Manager was not saved");                
            }
        }

        [TestMethod]
        public void Find_By_Email_Test()
        {
            // Arrange
            using (var dbService = new DataBaseService())
            {
                IManagerService managerService = new ManagerDBService(dbService);

                // Act
                var foundManager = managerService.FindManagerByEmail("user@mail.com");

                // Assert
                Assert.IsNotNull(foundManager, "Manager was not found");
            }
        }

        [TestMethod]
        public void Remove_By_Email_Test()
        {
            // Arrange
            using (var dbService = new DataBaseService())
            {
                IManagerService managerService = new ManagerDBService(dbService);

                // Act
                var result = managerService.RemoveManagerByEmail("user@mail.com");

                // Assert
                Assert.IsTrue(result, "Manager was not removed");
            }
        }
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
