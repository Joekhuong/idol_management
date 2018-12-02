using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lodi.Models;
using Microsoft.AspNet.Identity;

namespace Lodi.Controllers
{
    public class IdolsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult GetIdolListJson()
        {
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());

            var idols = user.Idols.ToList<Idol>();

            var list = db.Idols.AsEnumerable().Select(
                obj => new
                    {
                        Id = obj.Id,
                        Name = obj.Name,
                        Birthday = obj.Birthday.ToString("dd-MM-yyyy"),
                        ImageUrl = obj.ImageUrl,
                        Followed = idols.Contains(obj),
                        IsAdmin = user.IsAdmin
                }
                );

            if (user.Equals(null))
            {
                return HttpNotFound();
            }

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        // POST: Idols/Delete/5
        [HttpPost, ActionName("Follow")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> FollowConfirmed(Guid id)
        {
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            Idol idol = await db.Idols.FindAsync(id.ToString());
            idol.Followers.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Idols
        public async Task<ActionResult> Index()
        {
            return View(await db.Idols.ToListAsync());
        }

        // GET: Idols/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idol idol = await db.Idols.FindAsync(id.ToString());
            if (idol == null)
            {
                return HttpNotFound();
            }
            return View(idol);
        }

        // GET: Idols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Idols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Birthday,ImageUrl")] Idol idol)
        {
            if (ModelState.IsValid)
            {
                idol.Id = Guid.NewGuid().ToString();
                db.Idols.Add(idol);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(idol);
        }

        // GET: Idols/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idol idol = await db.Idols.FindAsync(id.ToString());
            if (idol == null)
            {
                return HttpNotFound();
            }
            return View(idol);
        }

        // POST: Idols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Birthday,ImageUrl")] Idol idol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idol).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(idol);
        }

        // GET: Idols/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idol idol = await db.Idols.FindAsync(id.ToString());
            if (idol == null)
            {
                return HttpNotFound();
            }
            return View(idol);
        }

        // POST: Idols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Idol idol = await db.Idols.FindAsync(id.ToString());
            db.Idols.Remove(idol);
            await db.SaveChangesAsync();
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
