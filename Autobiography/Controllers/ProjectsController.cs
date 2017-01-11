using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Autobiography.Models;
using Microsoft.AspNet.Identity;

namespace Autobiography.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projects
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        [HttpGet]
        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ViewM = from o in db.Projects join o2 in db.Comments on o.ID equals o2.ProjectID where o.ID == o2.ProjectID && o.ID == (int)id select new ProjectsViewModel { Project = o, Comments = o2 };

            return View(ViewM);
        }

        [HttpPost]
        public ActionResult Details(int? id, string txtComment)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comments = new Comment();

            if (!(String.IsNullOrEmpty(txtComment)))
            {
                comments.ProjectID = (int)id;
                comments.CommentContent = txtComment;
                comments.SubmittedBy = User.Identity.GetUserName().Substring(0, User.Identity.GetUserName().IndexOf("@"));

                db.Comments.Add(comments);
                db.SaveChanges();

             //   HttpCookie cookie = new HttpCookie("Cookie");
             //   cookie.Value = "You have already added a comment!";
             //   ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }

            var ViewM = from o in db.Projects join o2 in db.Comments on o.ID equals o2.ProjectID where o.ID == o2.ProjectID && o.ID == (int)id select new ProjectsViewModel { Project = o, Comments = o2 };

            return View(ViewM);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Type,Website,GitHub")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(projects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projects);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Type,Website,GitHub")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projects);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projects projects = db.Projects.Find(id);
            db.Projects.Remove(projects);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //[HttpPost]
        //public ActionResult AddComment(int id, string newComment)
        //{
        //    Comment comments = new Comment();

        //    if (!(String.IsNullOrEmpty(newComment)))
        //    {
        //        comments.ProjectID = (int)id;
        //        comments.CommentContent = newComment;
        //        comments.SubmittedBy = User.Identity.GetUserName();

        //        db.Comments.Add(comments);
        //        db.SaveChanges();
        //    }

        //    return View("Details/" + id);
        //}
    }
}
