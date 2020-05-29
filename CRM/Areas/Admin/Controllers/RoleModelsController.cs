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
    public class RoleModelsController : Controller
    {
        private IRoleModelRepositories _roleModelRepositories;
        CRM_Sepehr db = new CRM_Sepehr();
        public RoleModelsController()
        {
            _roleModelRepositories = new RoleModelRepositories(db);
        }

        // GET: Admin/RoleModels
        public ActionResult Index()
        {
            return View(_roleModelRepositories.GetAllRoles());
        }

        // GET: Admin/RoleModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var roleModel = _roleModelRepositories.GetRoleById(id.Value);
            if (roleModel == null)
            {
                return HttpNotFound();
            }
            return View(roleModel);
        }

        // GET: Admin/RoleModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RoleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleID,Role,Enabled")] RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                _roleModelRepositories.InsertRole(roleModel);
                _roleModelRepositories.save();
                return RedirectToAction("Index");
            }

            return View(roleModel);
        }

        // GET: Admin/RoleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RoleModel roleModel = _roleModelRepositories.GetRoleById(id.Value);

            if (roleModel == null)
            {
                return HttpNotFound();
            }
            return View(roleModel);
        }

        // POST: Admin/RoleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleID,Role,Enabled")] RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                _roleModelRepositories.UpdateRole(roleModel);
                _roleModelRepositories.save();
                return RedirectToAction("Index");
            }
            return View(roleModel);
        }

        // GET: Admin/RoleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RoleModel roleModel = _roleModelRepositories.GetRoleById(id.Value);
            if (roleModel == null)
            {
                return HttpNotFound();
            }
            return View(roleModel);
        }

        // POST: Admin/RoleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _roleModelRepositories.DeleteRole(id);
            _roleModelRepositories.save();
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _roleModelRepositories.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
