using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotallyNotJira.Models;

namespace TotallyNotJira.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectDBContext db = new ProjectDBContext();
        // GET: Project
        public ActionResult Index()
        {
            ViewBag.Projects = db.Projects.OrderBy(x => x.Name);

            return View();
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Project = db.Projects.Find(id);

            return View();
        }

        // GET: Project/Create
        public ActionResult New()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult New(Project project)
        {
            try
            {
                db.Projects.Add(project);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Project = db.Projects.Find(id);

            return View();
        }

        // POST: Project/Edit/5
        [HttpPut]
        public ActionResult Edit(int id, Project updatedProject)
        {
            try
            {
                Project project = db.Projects.Find(id);

                if (TryUpdateModel(project))
                {
                    project.Name = updatedProject.Name;
                    project.Description = updatedProject.Description;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
