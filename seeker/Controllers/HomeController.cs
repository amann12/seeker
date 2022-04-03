using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using seeker.Models;
using seeker.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace seeker.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment _ihosting;

        public IDeveloper _devloperRepo;
        public HomeController(IDeveloper _devloperRepo, IHostingEnvironment _ihosting)
        {
            this._devloperRepo = _devloperRepo;
            this._ihosting = _ihosting;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }  
        public IActionResult Team()
        {
            return View();
        }
        public IActionResult SingleDetails(int Id)
        {
            Developer d = _devloperRepo.GetDeveloper(Id);
            SingleDetailsViewModel singleDetailsViewModel = new SingleDetailsViewModel
            {
                Id = d.Id,
                devName = d.devName,
                devEmail = d.devEmail,
                devPhoneNumber = d.devPhoneNumber,
                devFrom = d.devFrom,
                devAbout = d.devAbout,
                devProject = d.devProject,
                devGitHub = d.devGitHub,
                PhotoPath = d.Photo
            };
            return View(singleDetailsViewModel);
        }
        public IActionResult AllDetails()
        {
            var data = _devloperRepo.GetAllDetails();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddDeveloper()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DeveloperViewModel model)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_ihosting.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Developer newDeveloper = new Developer
                {
                    devName = model.devName,
                    devEmail = model.devEmail,
                    devPhoneNumber = model.devPhoneNumber,
                    devFrom = model.devFrom,
                    devAbout = model.devAbout,
                    devProject = model.devProject,
                    devGitHub = model.devGitHub,
                    Photo = uniqueFileName

                };
                _devloperRepo.Add(newDeveloper);
                return RedirectToAction("AllDetails", new { Id = newDeveloper.Id });

            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Developer developer= _devloperRepo.GetDeveloper(Id);
            EditDeveloperViewModel editDeveloperViewModel = new EditDeveloperViewModel
            {
                Id = developer.Id,
                devName = developer.devName,
                devEmail = developer.devEmail,
                devPhoneNumber = developer.devPhoneNumber,
                devFrom = developer.devFrom,
                devAbout = developer.devAbout,
                devProject = developer.devProject,
                devGitHub = developer.devGitHub,
                PhotoPath = developer.Photo
            };
            return View(editDeveloperViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditDeveloperViewModel model)
        {
            if (ModelState.IsValid)
            {
                Developer developer= _devloperRepo.GetDeveloper(model.Id);
                developer.devName= model.devName;
                developer.devEmail = model.devEmail;
                    developer.devPhoneNumber = model.devPhoneNumber;
                developer.devFrom = model.devFrom;
                developer.devAbout = model.devAbout;
                developer.devProject = model.devProject;
                developer.devGitHub = model.devGitHub;

                if (model.Photo != null)
                {
                    if (model.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_ihosting.WebRootPath, "images", model.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    developer.Photo = ProcessUploadedFile(model);
                }
                Developer updatedEmployee = _devloperRepo.Update(developer);
                return RedirectToAction("AllDetails");
            }
            return View(model);
        }

        private string ProcessUploadedFile(EditDeveloperViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_ihosting.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public IActionResult Delete(int Id)
        {
            _devloperRepo.Delete(Id);
            return RedirectToAction("AllDetails");

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
