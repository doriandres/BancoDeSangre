using System.Collections.Generic;
using BancoDeSangre.Models;

namespace BancoDeSangre.Services.CampaignService
{
    public interface ICampaignService
    {
        /// <summary>
        /// Adds a Canmpaign in the DB
        /// </summary>
        /// <param name="campaign">Campaign to be created</param>
        /// <returns>Result of the campaign creation</returns>
        bool CreateCampaign(Campaign campaign);

        /// <summary>
        /// Finds a Campaign by ID
        /// </summary>
        /// <param name="id">Id of the desired Campaign</param>
        /// <returns>Found Campaign</returns>
        Campaign FindByID(int id);

        /// <summary>
        /// Finds all the campaigns
        /// </summary>
        /// <returns>Campaigns list</returns>
        List<Campaign> FindAll();

        /// <summary>
        /// Validates a Campaign
        /// </summary>
        /// <param name="campaign">Campaign to validate</param>
        /// <param name="cause">Invalid cause</param>
        /// <returns>Result</returns>
        bool IsValidCampaign(Campaign campaign, out string cause);
    }
}
