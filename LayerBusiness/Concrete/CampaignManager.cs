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
        ICampaignDal _campaignDal; private readonly IProductDal _productDal;

        public CampaignManager(ICampaignDal campaignDal, IProductDal productDal)
        {
            _campaignDal = campaignDal;
            _productDal = productDal;
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

        public Campaign TGetByID(int id)
        {
            return _campaignDal.GetByID(id);
        }

        public List<Campaign> GetActiveCampaigns()
        {
            return _campaignDal.List(c => c.StartDate <= DateTime.Today && c.EndDate >= DateTime.Today);
        }


       
    }
}

