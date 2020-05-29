using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace CRM.Areas.Admin.Controllers
{
    public class UsersModelsController : Controller
    {
        private IUserModelRepositories userModelRepositories;
        private CRM_Sepehr db = new CRM_Sepehr();

        public UsersModelsController()
        {
            userModelRepositories = new UsersModelRepositories(db);
        }

        // GET: Admin/UsersModels
        public ActionResult Index()
        {
            var usersModels = db.UsersModels.Include(u => u.RoleModel);
            return View(usersModels.ToList());
        }

        // GET: Admin/UsersModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersModel usersModel = db.UsersModels.Find(id);
            if (usersModel == null)
            {
                return HttpNotFound();
            }
            return View(usersModel);
        }

        // GET: Admin/UsersModels/Create
        public ActionResult Create()
        {

            ViewBag.RoleID = new SelectList(db.RoleModels, "RoleID", "Role");
            return View();
        }

        // POST: Admin/UsersModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FName,LName,FullName,AddressOne,AddressTwo,PhoneNumber,Mobile,FaxNumber,CompanyName,DateTimeRegister,Email,WebSite,RoleID,EnableUser")] UsersModel usersModel,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                usersModel.DateTimeRegister = DateTime.Now;
                db.UsersModels.Add(usersModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.RoleModels, "RoleID", "Role", usersModel.RoleID);
            return View(usersModel);
        }

        // GET: Admin/UsersModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersModel usersModel = db.UsersModels.Find(id);
            if (usersModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.RoleModels, "RoleID", "Role", usersModel.RoleID);
            return View(usersModel);
        }

        // POST: Admin/UsersModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FName,LName,FullName,AddressOne,AddressTwo,PhoneNumber,Mobile,FaxNumber,CompanyName,DateTimeRegister,Email,WebSite,RoleID,EnableUser")] UsersModel usersModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.RoleModels, "RoleID", "Role", usersModel.RoleID);
            return View(usersModel);
        }

        // GET: Admin/UsersModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersModel usersModel = db.UsersModels.Find(id);
            if (usersModel == null)
            {
                return HttpNotFound();
            }
            return View(usersModel);
        }

        // POST: Admin/UsersModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersModel usersModel = db.UsersModels.Find(id);
            db.UsersModels.Remove(usersModel);
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
    }
}
