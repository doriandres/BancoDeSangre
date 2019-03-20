using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using BancoDeSangre.Services.DonorService;
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
        public void Create_Medical_Center_Name()
        {

            //Arrange 
            using (var dbService = new DataBaseService())
            {
                IMedicalCenterService medicalCenter = new MedicalCenterDBService(dbService);

            // Act
            var resultado = medicalCenter.CreateMedicalCenter("medicalCenter");


                // Assert
                Assert.IsTrue(resultado, "MedicalCenter");
            }
        }

        [TestMethod]
        public void Create_Medical_Center_id()
        {
            //Arrange
            using (var dbService = new DataBaseService())
            {
                IMedicalCenterService medicalCenter = new MedicalCenterDBService(dbService);

                // Act
                bool resultado = medicalCenter.FindByID();
               

                // Assert
                Assert.IsTrue(resultado, "id");
            }
        }
        [TestMethod]
        public void Valid_Donor()
        {
            //Arrange
            using (var dbService = new DataBaseService())
            {
                IDonorService countChanges = new DonorDBService(dbService);

                // Act
                var resultado = countChanges.IsValidDonor();


                // Assert
                Assert.IsTrue(resultado, "Debe ingresar un nombre");
            }
        }

    }
}
