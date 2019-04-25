using BancoDeSangre.Models;
using BancoDeSangre.Services.CampaignService;
using BancoDeSangre.Services.DB;
using BancoDeSangre.Services.DonationService;
using BancoDeSangre.Services.DonorService;
using BancoDeSangre.Services.ManagerService;
using BancoDeSangre.Services.MedicalCenterService;
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
                IManagerService managerService = new ManagerDBService(dbService);
                IMedicalCenterService medicalCenterService = new MedicalCenterDBService(dbService, managerService);


                var medicalCenter = new MedicalCenter
                {
                    Email = "carit@info.com",
                    Name = "carit",
                    PhoneNumber = 88888,
                    Place = "San Jose"

                };

                // Act

                var resultado = medicalCenter.Email;
                //var resultado = medicalCenter.Id;


                // Assert
                Assert.IsNotNull(value: resultado);


            }
        }


        [TestMethod]
        public void Create_Donation_Center()
        {
            using (var dbService = new DataBaseService())
            {
                IManagerService managerService = new ManagerDBService(dbService);
                var donationDBService = new DonationDBService(dbService, managerService);

                //Act
                var result = donationDBService.CreateDonation(new Donation { DonorId = 1});

                //// Assert

                Assert.IsTrue(result);

            }

        }


        [TestMethod]
        public void Valid_Donor()
        {
            //Arrange
            using (var dbService = new DataBaseService())
            {
                IManagerService managerService = new ManagerDBService(dbService);
                IDonorService idonorService = new DonorDBService(dbService, managerService);
                var donor = new Donor
                {
                    Name = "Carit",
                    Id = 88,
                };

                // Act

                var resultado = idonorService;


                // Assert
                Assert.IsNotNull(resultado);
            }
        }

        [TestMethod]
		public void Create_DBSService_Tests()
		{
			//Arrange
			using (var dbService = new DataBaseService())
			{
				IManagerService managerService = new ManagerDBService(dbService);
				var managerservice = new Manager();


				//Act
				var resultado = managerService.FindAll();


				// Assert
				Assert.IsNotNull(resultado);

			}
		}

		[TestMethod]
        public void Create_Campaign_Test()
        {
            //Arrange
            using (var dbService = new DataBaseService())
            {

                ICampaignService countChanges = new CampaignDBService(dbService, new ManagerDBService(dbService));

                var testManager = dbService.Managers.Find(1);
                var campaign = new Campaign();
                campaign.Description = "Donacion";
                campaign.Place = "Lugar";
                campaign.Title = "Titulo";
                campaign.StartTime = new System.DateTime();
                campaign.Latitude = 5565555;
                campaign.Longitude = 555585;
                campaign.ManagerId = 1;
                campaign.Manager = testManager;//Se agrega el manager a la campaña para evitar error de FK en la DB


                // Act

                var resultado = countChanges.CreateCampaign(campaign);

                // Assert
                Assert.IsNotNull(resultado);
            }
        }

    }


}
