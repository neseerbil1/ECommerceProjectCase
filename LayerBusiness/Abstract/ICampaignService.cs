using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness.Abstract
{
    public interface ICampaignService:IGenericService<Campaign>
    {
       List<Campaign> GetActiveCampaigns();
        Campaign TGetByID(int id);
       

    }
}
