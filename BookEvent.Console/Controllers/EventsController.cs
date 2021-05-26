using BookEvent.Data.Model;
using BookEvent.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using System.Web.Mvc;

namespace BookEvent.Console.Controllers
{
    public class EventsController : Controller
    {
        private readonly IBookData db;

        public EventsController(IBookData db)
        {
            this.db = db;
        }

        // GET: Events
        public ActionResult Index()
        {
            var model = db.getAll();
            return View(model);
        }

        //provide details of a speacific event
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            return View(model);
        }

        //redirect to view page of create event
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //creates a new event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event eve)
        {
            if (ModelState.IsValid)
            {
                Inviteduser iu = new Inviteduser();
                iu.Gmail = eve.Invite;
                db.Add(eve);
                db.AddEventId(iu, eve.Id);
                return RedirectToAction("Index");
            }

            return View();
        }

        //return a view for edit event
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //edit a speacific event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event eve)
        {
            if (ModelState.IsValid)
            {
                db.Update(eve);
                TempData["Message"] = "You Event is Updated!!";
                return RedirectToAction("Details", new { id = eve.Id });
            }
            return View(eve);
        }

        //delete a speacific event
        public ActionResult Delete(Event eve)
        {
            db.Delete(eve);
            return RedirectToAction("Index");
        }

        //Login Funtionalities
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var obj = db.Login(user);
            if (obj != null)
            {
                Session["Gmail"] = obj.Gmail.ToString();
                Session["Pass"] = obj.Password.ToString();
                Session["Name"] = obj.Name.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Gmail", "You have entered Wrong Email or password!");
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            Session["Email"] = null;
            Session["Pass"] = null;
            Session.Abandon();
            return RedirectToAction("Login");
        }

        //Register functionality
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Register(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }
    }
}