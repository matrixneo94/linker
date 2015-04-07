using Mvc_project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using PagedList;

namespace Mvc_project.Controllers
{
    public class HomeController : Controller
    {
        MVCProjectDB _db = new MVCProjectDB();
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
        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            Link link = _db.Links.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Link movie = _db.Links.Find(id);
            _db.Links.Remove(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
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
                            Author = r.Author

                        }).ToPagedList(page, 10);
                    return View(list);
                    break;
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
                            Author = r.Author

                        }).ToPagedList(page, 10);
                    return View(list);
                    break;
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
                            Author = r.Author

                        }).ToPagedList(page, 10);
                    return View(list);
                    break;
                }
                default:
                break;
            }
            return new HttpNotFoundResult();
         
        }
        public ActionResult Edit(int id = 0)
        {
            Link links = _db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }
        public ActionResult Details(int id = 0)
        {
            Link links = _db.Links.Find(id);
            if (links == null)
            {
                return HttpNotFound();
            }
            return View(links);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Link links)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(links).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(links);
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
