using JobTrackerApp.Models.JobApplicationModels;
using JobTrackerApp.Services.JobApplicationServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace JobTrackerApp.WebMVC.Controllers.JobApplicationController
{
    public class JobApplicationController : Controller
    {
        // GET: JobApplication
        public ActionResult Index()
        {
            var service = CreateJobApplicationService();
            var model = service.GetJobApplications();
            return View(model);
        }

        // JobApplication/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobApplicationCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateJobApplicationService();

            if (service.CreateJobApplication(model))
            {
                TempData["SaveResult"] = "Your Job Application was created successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Job Application could not be created. Try again later...");

            return View(model);
         }

        // JobApplication/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateJobApplicationService();
            var model = service.GetJobApplicationById(id);

            if(model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(model);
        }

        // JobApplication/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateJobApplicationService();
            var detail = service.GetJobApplicationById(id);
            var model = new JobApplicationEdit
            {
                JobApplicationId = id,
                ApplicationMaterials = detail.ApplicatonMaterials,
                ContactPerson = detail.ContactPerson,
                ContactInformation = detail.ContactInformation,
                ApplicationNotes = detail.ApplicationNotes,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobApplicationEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.JobApplicationId != id)
            {
                ModelState.AddModelError("", "ID does not Match");
                return View(model);
            }

            var service = CreateJobApplicationService();

            if (service.UpdateJobApplication(model))
            {
                TempData["SaveResult"] = "Your Job Application was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Job Application could not be updated. Try again later...");
            return View(model);
        }

        // JobApplication/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateJobApplicationService();
            var model = service.GetJobApplicationById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteJobApplication(int id)
        {
            var service = CreateJobApplicationService();
            service.DeleteJobApplication(id);
            TempData["SaveResult"] = "Your Job Application was successfully deleted.";
            return RedirectToAction("Index");
        }
 
        public JobApplicationService CreateJobApplicationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobApplicationService(userId);
            return service;
        }
    }
}