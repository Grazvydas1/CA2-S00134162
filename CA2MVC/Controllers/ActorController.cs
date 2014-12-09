using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA2MVC.Controllers;
using CA2MVC.Models;
using System.Data.Entity;
using System.Data;

namespace CA2MVC.Controllers
{
    public class ActorController : Controller
    {
        private MovieDB db = new MovieDB();

        public ActionResult Index()
        {

            return View(db.Actors.ToList());
        }

       

        public ActionResult Details(int id)
        {
            Actor actor = db.Actors.Find(id);
            
            return View(actor);
        }

   

        public ActionResult Create(int mid)
        {
            Actor ac = new Actor { MovieID = mid };
            return View();
        }

       

        [HttpPost]
        public ActionResult Create(Actor actor,int mid)
        {
            actor.MovieID = mid;
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Details");
            }
                return View(actor);
            
        }

      

        public ActionResult Edit(int id)
        {
            Actor actor = db.Actors.Find(id);
            
            return View(actor);
        }

      

        [HttpPost]
        public ActionResult Edit(Actor actor,int mid)
        {
            if (ModelState.IsValid)
            {
                actor.MovieID = mid;
                db.Entry(actor).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(actor);
            
        }

  

        public ActionResult Delete(int id=0)
        {
            Actor actor = db.Actors.Find(id);
           
            return View(actor);
        }

 

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Actor actor = db.Actors.Find(id);
            db.Actors.Remove(actor);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }
    }
}
