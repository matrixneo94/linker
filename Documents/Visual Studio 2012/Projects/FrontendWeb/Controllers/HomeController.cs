using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using FrontenedWeb.Models;
using PagedList;

namespace FrontenedWeb.Controllers
{
    public class HomeController : Controller
    {

     
        MvcProjectDb _db = new MvcProjectDb();
        public ActionResult Autocomplete(string temp)
        {
            var list = _db.Links.OrderByDescending(r => r.Raiting)
               .Where(r => r.Title.StartsWith(temp))
               .Take(10)
               .Select(r => new
               {
                   Title = r.Title,
               }

               );
            return Json(list, JsonRequestBehavior.AllowGet);
        }
 
        public ActionResult IncreaseRaiting(int id =0)
        {
            Link links = _db.Links.Find(id);
            links.Raiting = ++links.Raiting;
            _db.Entry(links).State = EntityState.Modified;
            _db.SaveChanges();
            
            return RedirectToAction("Index");

        }
        public ActionResult DecreaseRaiting(int id = 0)
        {
            Link links = _db.Links.Find(id);
            links.Raiting = --links.Raiting;
            _db.Entry(links).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");

        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lists/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Link links)
        {
            links.AddDate = DateTime.Now.ToString();
            string username = Membership.GetUser().UserName;
            links.Author = _db.UsersBase.Where(u => u.UserName.Equals(username)).First();
            if (ModelState.IsValid)
            {
                _db.Links.Add(links);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(links);
        }
        public ActionResult Index(string search = null, int page =1,int sortBy = 0)
        {
            switch (sortBy)
            {
                case 0:
                {
                    var list = _db.Links.OrderByDescending(r => r.Raiting)
                        .Where(r => search == null || r.Title.StartsWith(search.ToLower()))
                        .Select(r => new LinksListViewModel
                        {
                            ID = r.ID,
                            Link = r.URL,
                            Title = r.Title,
                            Raiting = r.Raiting,
                            ShortDescription = r.ShortDescription,
                            Author = r.Author,
                            AddDate = r.AddDate

                        }).ToPagedList(page, 10);
                    return View(list);
                   
       
                }
                case 1:
                {
                    var list = _db.Links.OrderBy(r => r.Title)
                        .Where(r => search == null || r.Title.StartsWith(search.ToLower()))
                        .Select(r => new LinksListViewModel
                        {
                            ID = r.ID,
                            Link = r.URL,
                            Title = r.Title,
                            Raiting = r.Raiting,
                            ShortDescription = r.ShortDescription,
                            Author = r.Author,
                            AddDate = r.AddDate

                        }).ToPagedList(page, 10);
                    return View(list);
   
                }
                case 2:
                {
                    var list = _db.Links.OrderByDescending(r => r.AddDate)
                        .Where(r => search == null || r.Title.StartsWith(search.ToLower()))
                        .Select(r => new LinksListViewModel
                        {
                            ID = r.ID,
                            Link = r.URL,
                            Title = r.Title,
                            Raiting = r.Raiting,
                            ShortDescription = r.ShortDescription,
                            Author = r.Author,
                            AddDate = r.AddDate

                        }).ToPagedList(page, 10);
                    return View(list);
          
                }
                default:
                break;
            }
            return new HttpNotFoundResult();
         
        }
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Link links = _db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Link links = _db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Link links)
        {
            links.AddDate = DateTime.Now.ToString();
            if (ModelState.IsValid)
            {
                _db.Entry(links).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(links);
        }
        [Authorize]
        public ActionResult Delete(int? id)
        {
            
            Link link = _db.Links.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // POST: 
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Link movie = _db.Links.Find(id);
            _db.Links.Remove(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
