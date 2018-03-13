using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaLul.Models;

namespace CinemaLul.Controllers
{
    public class ShowController : Controller
    {
        // GET: Shows
        public ActionResult List()
        {
            ShowView[] shows;
            using (var data = new lulCinemaEntities())
            {
                shows = data.Shows.OrderByDescending(x=>x.time).AsEnumerable()
                    .Select(x => new ShowView { Id = x.Id, name = x.name, time = x.time }).ToArray();
            }
            return View(shows);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name, DateTime time)
        {
            using (var data = new lulCinemaEntities())
            {
                data.Shows.Add(new Show
                {
                    name = name,
                    time = time
                });
                data.SaveChanges();
            }
            return Redirect("/");
        }
        public ActionResult Edit(int id)
        {
            using (var data = new lulCinemaEntities())
            {
                Show show = data.Shows.Find(id);
                if (show == null)
                    return Redirect("/");
                return View(new ShowView
                {
                    Id = show.Id,
                    name = show.name,
                    time = show.time
                });
            }

        }
        [HttpPost]
        public ActionResult Edit(int id, string name, DateTime time)
        {
            using (var data = new lulCinemaEntities())
            {
                Show s = data.Shows.Find(id);
                if(s == null)
                    return Redirect("/");
                s.name = name;
                s.time = time;
                data.SaveChanges();
            }
            return Redirect("/");
        }
    }
}