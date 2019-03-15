using System;
using System.Collections.Generic;
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

        public List<Campaign> FindAll()
        {
            return dataBase.Campaigns.ToList();
        }

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

            return valid;
        }
    }
}