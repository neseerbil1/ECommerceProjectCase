using LayerBusiness.Abstract;
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
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }



        // GET: Campaign
        public ActionResult Index()
        {
            var campaigns = _campaignService.GetList();
            return View(campaigns);
        }
      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Campaign campaign)
        {
            _campaignService.TAdd(campaign);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var campaign = _campaignService.TGetByID(id);
            return View(campaign);
        }

        [HttpPost]
        public ActionResult Edit(Campaign campaign)
        {
            _campaignService.TUpdate(campaign);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var campaign = _campaignService.TGetByID(id);
            return View(campaign);
        }

        [HttpPost]
        public ActionResult Delete(Campaign campaign)
        {
            _campaignService.TDelete(campaign);
            return RedirectToAction("Index");
        }
    }
}