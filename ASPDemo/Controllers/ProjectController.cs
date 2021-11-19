using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPDemo.Core;

namespace ASPDemo.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            var projects = ProjectStorage.Projects;
            return View(projects);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Project project)
        {
            ProjectStorage.Add(project);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(Project project)
        {
            ProjectStorage.RemoveByName(project);
            return RedirectToAction("Index");
        }
    }
}
