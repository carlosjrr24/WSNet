using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSNet.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Net;


using System.Data;
using System.Data.Entity;


namespace WSNet.Controllers
{

        [Authorize]
        public class RoleController : Controller
        {
            private StoreContext db = new StoreContext();

            // GET: Roles
            public ActionResult Index()
            {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View(db.Roles.ToList());
            }

            // GET: Role/Details/5
            public ActionResult Details(string id)
            {

            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


            if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                IdentityRole Role = db.Roles.Find(id);
                if (Role == null)
                {
                    return HttpNotFound();
                }
                return View(Role);
            }

        // GET: Role/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole Role = db.Roles.Find(id);
            if (Role == null)
            {
                return HttpNotFound();
            }
            if (Role.Name !="Admin")
            {
                return View(Role);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] IdentityRole Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Role);
        }


        // GET: Role/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole Role = db.Roles.Find(id);
            if (Role == null)
            {
                return HttpNotFound();
            }
            return View(Role);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            IdentityRole Role = db.Roles.Find(id);
            db.Roles.Remove(Role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





        public Boolean isAdminUser()
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var user = User.Identity;
                        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                        var s = UserManager.GetRoles(user.GetUserId());
                        if (s[0].ToString() == "Admin")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return false;
                }

            /// <summary>
            /// Create  a New role
            /// </summary>
            /// <returns></returns>
            public ActionResult Create()
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (!isAdminUser())
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                var Role = new IdentityRole();
                return View(Role);
            }

            /// <summary>
            /// Create a New Role
            /// </summary>
            /// <param name="Role"></param>
            /// <returns></returns>
            [HttpPost]
            public ActionResult Create(IdentityRole Role)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (!isAdminUser())
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                db.Roles.Add(Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
