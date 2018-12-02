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
using System.Web.UI;
using Microsoft.AspNet.Identity.Owin;

namespace Lodi.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profile
        public ActionResult Index()
        {

            string userId = User.Identity.GetUserId();

            return Details(userId);

        }

        // GET: Profile/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            ProfileViewModel model = new ProfileViewModel()
            {
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                Region = user.Region,
                Idol_List = new System.Web.Mvc.SelectList(user.Idols.ToList<Idol>(), "Id", "Name")
            };

            return View(model);
        }
    }
}
