using LayerBusiness.Abstract;
using LayerDataAccess.Abstract;
using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness.Concrete
{
    public class CampaignManager : ICampaignService
    {
        ICampaignDal _campaignDal;
      

        public CampaignManager(ICampaignDal campaignDal)
        {
            _campaignDal = campaignDal;
        }

        public List<Campaign> GetList()
        {
            return _campaignDal.List();
        }

        public void TAdd(Campaign t)
        {
            _campaignDal.Insert(t);
        }

        public void TDelete(Campaign t)
        {
            _campaignDal.Delete(t);
        }

        public void TUpdate(Campaign t)
        {
            _campaignDal.Update(t);
        }
        // Method to get active campaigns
        public List<Campaign> GetActiveCampaigns()
        {
            var now = DateTime.Now;

            var activeCampaigns = _campaignDal.List(c => c.StartDate <= now && c.EndDate >= now);

            return activeCampaigns;
        }

        public Campaign TGetByID(int id)
        {
            return _campaignDal.GetByID(id);
        }
    }
}
