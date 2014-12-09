using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA2MVC.Models;
using System.Data.Entity;
using System.Data;

namespace CA2MVC.Controllers
{
    public class HomeController : Controller
    {
       private MovieDB db = new MovieDB();
        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View(db.Movies.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id =0)
        {
            Movie m = db.Movies.Find(id);
            
           
                m.Actors = (from e in db.Actors where e.MovieID.Equals(id) select e).ToList();
            
            return View(m);
        }

       

        public ActionResult Create()
        {
            return View();
        }

      

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }  
            
            
             return View(movie);
            
        }

     

        public ActionResult Edit(int id)
        {
            Movie movie = db.Movies.Find(id);
           
            return View(movie);
        }

       

        [HttpPost]
        public ActionResult Edit (Movie movie)
        {
            
                db.Entry(movie).State =EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            
           
            
                return View(movie);
            
        }

       

        public ActionResult Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
          
            
           movie.Actors = (from e in db.Actors where e.MovieID.Equals(id) select e).ToList();
            
            return View(movie);
        }

      

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
                

                return RedirectToAction("Index");
            
           
        }
    }
}
