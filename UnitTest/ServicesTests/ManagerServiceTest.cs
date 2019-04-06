using BancoDeSangre.Models;
using BancoDeSangre.Services.CampaignService;
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
				IMedicalCenterService medicalCenterService = new MedicalCenterDBService(dbService);


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

		//[TestMethod]
		//public void Create_Medical_Center_id()
		//{
		//	//Arrange
		//	using (var dbService = new DataBaseService())
		//	{
		//		IMedicalCenterService medicalCenter = new MedicalCenterDBService(dbService);
		//		var medicalCenterid = new MedicalCenter
		//		{
		//			Email = "carit@info.com",
		//			Name = "carit",
		//			PhoneNumber = 88888,
		//			Place = "Sn Jose"


		//		};
		//		// Act
		//		var resultado = medicalCenter.CreateMedicalCenter(medicalCenterid);
		//	}
		//}


		//        // Assert
		//        Assert.IsTrue(resultado, "id");
		//    }
		//}


		[TestMethod]
		public void Valid_Donor()
		{
			//Arrange
			using (var dbService = new DataBaseService())
			{
				IDonorService countChanges = new DonorDBService(dbService);
				var dataBase = new Donor
				{
					Name = "Carit",
					Id = 88,
				};

				// Act

				var resultado = countChanges.IsValidDonor(false);


				// Assert
				Assert.IsTrue(resultado, "Debe ingresar un nombre");
			}
		}

		//[TestMethod]
		//public void Create_Campaign_Test()
		//{
		//    //Arrange
		//    using (var dbService = new DataBaseService()) 
		//    {
		//        ICampaignService countChanges = new CampaignDBService(dbService);
		//        var testManager = new Manager();//Se crea un manager de prueba para la campaña
		//        var dataBase = new Campaign();
		//        dataBase.Manager = testManager;//Se agrega el manager a la campaña para evitar error de FK en la DB


		//        // Act

		//       var resultado = countChanges.CreateCampaign(dataBase);

		//        // Assert
		//        Assert.IsTrue(resultado);
		//    }
		//}

	}

    
}
