using BookEvent.Data.Model;
using BookEvent.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookEvent.Console.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookData db;

        public HomeController(IBookData db)
        {
            this.db = db;
        }

        //shows the past and future events
        public ActionResult Index()
        {
            var list = db.getAll();
            return View(list);
        }

        //redirects to contact us page
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //returns the events in which the current logged in user is invited
        public ActionResult InvitedTo()
        {
            var data = db.getFromInvite();
            List<int> l = new List<int>();
            foreach (var i in data)
            {
                if (i.Gmail.Equals(Session["Gmail"]))
                {
                    l.Add(i.EventId);
                }
            }
            List<String> detailsList = getEventName(l);
            return View(detailsList);
        }

        //method to return name of sme selected events
        public List<String> getEventName(List<int> ll)
        {
            Event eve = new Event();
            List<String> list = new List<String>();
            var ed = db.getAll();
            foreach (var i in ed)
            {
                for (int j = 0; j < ll.Count; j++)
                {
                    if (i.Id == ll[j])
                    {
                        //eve = i;
                        eve.Title = i.Title;
                        eve.Id = i.Id;
                        list.Add(i.Title);
                        break;
                    }
                }
            }
            return list;
        }
    }
}