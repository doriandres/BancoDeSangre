using BancoDeSangre;
using BancoDeSangre.Services.ManagerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using BancoDeSangre.Services.DonationService;
using System;
using BancoDeSangre.Services.MedicalCenterService;
namespace UnitTest3
{
    [TestClass]
    public class CampaignControllerTests
    {
        [TestMethod]
        public void Controller_Campaign_Tests()
        {
            //Arrange
            var controller = new CampaignController();
            Session.IsSignedIn();
            var session = new Cread();

              //Act
              var resultado = RedirectToAction("Index", "Home");

            //Assert
            Assert.Fail();
        }
}
}
