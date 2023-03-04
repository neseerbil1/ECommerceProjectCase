using LayerBusiness.Abstract;
using LayerBusiness.Concrete;
using LayerDataAccess.EntityFramework;
using LayerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceProjectCase.Controllers
{
    public class CampaignController : Controller
    {
        CampaignManager cm = new CampaignManager(new EfCampaignDal(), new EfProductDal());

    
        // GET: Campaign
        public ActionResult Index()
        {
            var campaigns = cm.GetList();
            return View(campaigns);
        }
      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Campaign campaign)
        {
           cm.TAdd(campaign);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var campaign = cm.TGetByID(id);
            return View(campaign);
        }

        [HttpPost]
        public ActionResult Edit(Campaign campaign)
        {
            cm.TUpdate(campaign);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var campaign = cm.TGetByID(id);
            return View(campaign);
        }

        [HttpPost]
        public ActionResult Delete(Campaign campaign)
        {
            cm.TDelete(campaign);
            return RedirectToAction("Index");
        }
    }
}