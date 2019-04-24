using System;
using System.Collections.Generic;
using System.Linq;
using BancoDeSangre.Models;
using BancoDeSangre.Services.DB;
using BancoDeSangre.Services.ManagerService;

namespace BancoDeSangre.Services.CampaignService
{
    public class CampaignDBService : DBService, ICampaignService
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        private IManagerService managerService;
        public CampaignDBService(IDataBaseService dataBase, IManagerService managerService) : base(dataBase)
        {
            this.managerService = managerService;
        }

        /// <summary>
        /// Adds a Canmpaign in the DB
        /// </summary>
        /// <param name="campaign">Campaign to be created</param>
        /// <returns>Result of the campaign creation</returns>
        public bool CreateCampaign(Campaign campaign)
        {
            dataBase.Campaigns.Add(campaign);
            var countChanges = dataBase.SaveChanges();
            return true;
        }

        /// <summary>
        /// Finds a Campaign by ID
        /// </summary>
        /// <param name="id">Id of the desired Campaign</param>
        /// <returns>Found Campaign</returns>
        public Campaign FindByID(int id)
        {
            return dataBase.Campaigns.FirstOrDefault(campaign => campaign.Id == id);
        }

        /// <summary>
        /// Finds all the campaigns
        /// </summary>
        /// <returns>Campaigns list</returns>
        public List<Campaign> FindAll()
        {
            return dataBase.Campaigns.ToList();
        }

        /// <summary>
        /// Validates a Campaign
        /// </summary>
        /// <param name="campaign">Campaign to validate</param>
        /// <param name="cause">Invalid cause</param>
        /// <returns>Result</returns>
        public bool IsValidCampaign(Campaign campaign, out string cause)
        {
            var valid = true;
            cause = null;

            if (campaign.Date < DateTime.Today)
            {
                cause = "La fecha seleccionada ya pasó";
                valid = false;
            }

            if (campaign.Date == DateTime.Today && campaign.StartTime < DateTime.Now)
            {
                cause = "La hora de inicio es antes que la hora actual";
                valid = false;
            }

            if (campaign.EndTime < campaign.StartTime)
            {
                cause = "La hora de finalización es antes que la hora de inicio";
                valid = false;
            }

            if (campaign.EndTime < campaign.StartTime)
            {
                cause = "La hora de finalización es antes que la hora de inicio";
                valid = false;
            }

            if (campaign.ManagerId == 0 || managerService.FindManagerById(campaign.ManagerId) == null)
            {
                cause = "Administrador inválido";
                valid = false;
            }

            return valid;
        }
    }
}