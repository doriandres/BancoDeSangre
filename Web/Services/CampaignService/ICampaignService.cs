using System.Collections.Generic;
using BancoDeSangre.Models;

namespace BancoDeSangre.Services.CampaignService
{
    public interface ICampaignService
    {
        bool CreateCampaign(Campaign campaign);

        Campaign FindByID(int id);

        List<Campaign> FindAll();
       
        bool IsValidCampaign(Campaign campaign, out string cause);
    }
}
