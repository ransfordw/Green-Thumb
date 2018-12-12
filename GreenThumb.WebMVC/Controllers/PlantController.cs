using GreenThumb.Data;
using GreenThumb.Models.PlantModels;
using GreenThumb.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenThumb.WebMVC.Controllers
{
    public class PlantController : Controller
    {
        // GET: Plant
        public ActionResult Index()
        {
            var svc = CreatePlantService();
            var model = svc.GetPlants();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlantCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreatePlantService();

            if (service.CreatePlant(model))
            {
                TempData["SaveResult"] = "Your plant is growing!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Item could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePlantService();
            var model = svc.GetPlantById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePlantService();
            var detail = service.GetPlantById(id);
            var model =
                new PlantEdit
                {
                    PlantID = detail.PlantID,
                    TypeOfPlant = detail.TypeOfPlant,
                    SoilMix = detail.SoilMix,
                    TimeFertilized = detail.TimeFertilized,
                    TimeWatered = detail.TimeWatered,
                    WateringFrequency = detail.WateringFrequency,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlantEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.PlantID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlantService();

            if (service.UpdatePlant(model))
            {
                TempData["SaveResult"] = "Your Item was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Item could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreatePlantService();
            var model = svc.GetPlantById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlantService();

            service.DeletePlant(id);

            TempData["SaveResult"] = "Your Item was deleted.";

            return RedirectToAction("Index");
        }

        private PlantService CreatePlantService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlantService(userId);
            return service;
        }
    }
}