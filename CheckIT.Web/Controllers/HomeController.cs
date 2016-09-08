using CheckIT.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckIT.Web.Controllers
{
    public class HomeController : Controller
    {
        //

        private MoviesDBEntities _db = new MoviesDBEntities();

        //[Authorize(Roles = "admin")]
        [Authorize]
        public ActionResult Index()

        {
            


            //if (!User.IsInRole("amdmin")) {
            //    return View("NotInRole");
            //}
            return View(_db.MovieSet.ToList());

        }

        //

        // GET: /Home/Details/5 

        public ActionResult Details(int id)

        {

            return View();

        }

        //

        // GET: /Home/Create 

        public ActionResult Create()

        {

            return View();

        }

        //

        // POST: /Home/Create 

        [AcceptVerbs(HttpVerbs.Post)]

        //public ActionResult Create(FormCollection collection)
        
        public ActionResult Create([Bind(Exclude = "Id")] Movie movieToCreate)

        {

            if (!ModelState.IsValid)

                return View();

            //_db.AddToMovieSet(movieToCreate);
            _db.MovieSet.Add(movieToCreate);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        //

        // GET: /Home/Edit/5

        public ActionResult Edit(int id)

        {

            var movieToEdit = (from m in _db.MovieSet

                               where m.Id == id

                               select m).First();

            return View(movieToEdit);

        }

        //

        // POST: /Home/Edit/5 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Edit(Movie movieToEdit)

        {

            var originalMovie = (from m in _db.MovieSet

                                 where m.Id == movieToEdit.Id

                                 select m).First();

            if (!ModelState.IsValid)

                return View(originalMovie);
            _db.Entry(originalMovie).CurrentValues.SetValues(movieToEdit);
            //_db.ApplyPropertyChanges(originalMovie.EntityKey.EntitySetName, movieToEdit);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        //

        // GET: /Home/Delete/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Delete(int id)

        {

            var movieToDelete = (from m in _db.MovieSet

                               where m.Id == id

                               select m).First();

            return View(movieToDelete);

        }

        //

        // POST: /Home/Edit/5 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Delete(Movie movieToDelete)

        {

            var originalMovie = (from m in _db.MovieSet

                                 where m.Id == movieToDelete.Id

                                 select m).First();

            if (!ModelState.IsValid)

                return View(originalMovie);
            _db.MovieSet.Remove(originalMovie);
            //_db.ApplyPropertyChanges(originalMovie.EntityKey.EntitySetName, movieToEdit);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}