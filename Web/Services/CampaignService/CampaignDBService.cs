using System.Linq;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;

namespace BancoDeSangre.Services.CampaignService
{
    public class CampaignDBService : DBService, ICampaignService
    {
        public CampaignDBService(DataBaseService dataBase) : base(dataBase)
        {
        }

        public bool CreateCampaign(Campaign campaign)
        {
            dataBase.Campaigns.Add(campaign);
            var countChanges = dataBase.SaveChanges();
            return true;
        }

        public Campaign FindByID(int id)
        {
            return dataBase.Campaigns.FirstOrDefault(campaign => campaign.Id == id);
        }
    }
}