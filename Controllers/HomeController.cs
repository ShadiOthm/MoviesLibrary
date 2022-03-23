using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMP235MVCDemo.DataAccessObjects;
using COMP235MVCDemo.Models;


namespace COMP235MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Movie()
        {
            ViewBag.Message = "My Movie Page.";
            MovieDAO dAO = new MovieDAO();
            Movie m = dAO.getMovieById(2);
            return View(m);
        }

        public ActionResult AddMovie(Movie m, string Save) // each view need an Action Result Method to be viewed
        {
            ViewBag.Message = "Add A Movie Page";
            //Save is the name of the Value on the Button
            if (Save == "Save")
            {
                MovieDAO dAO = new MovieDAO();
                dAO.InsertMovie(m);
                ViewBag.Message = "Movie Added successfully";

            }
            return View("AddMovie");
        }

        

        public ActionResult Details(Movie movie)
        {
            MovieDAO dAO = new MovieDAO();
            movie = dAO.getMovieById(movie.Id);
            return View("Movie", movie);
        }

        public ActionResult DetailsUpdate(Movie movie , string Save)
        {
            MovieDAO dAO = new MovieDAO();
            if (!string.IsNullOrEmpty(Save) && Save == "Save")
            {
                dAO.updateMovie(movie);

                var movies = dAO.getAllMovies();
                return View("AllMovies", movies);
            }
            else
            {
                if (movie.Id != 0)
                {
                    movie = dAO.getMovieById(movie.Id);
                    return View("DetailsUpdate", movie);
                }
                var movies = dAO.getAllMovies();
                return View("AllMovies", movies);
            }

            
        }

        public ActionResult DetailsDelete(int? Id)
        {
            MovieDAO dAO = new MovieDAO();
            Movie movie = dAO.getMovieById(Id.Value);
            return View("DetailsDelete", movie);
        }

        public ActionResult MoviesEdit(int? id, Movie movies)
        {

            int id2 = id ?? default(int);
            MovieDAO dAO = new MovieDAO();
            movies = dAO.getAllMovies();
            movies.EditIndex = dAO.setMovieToEditMode(movies.Items, id2);
            ViewBag.Message = "All movies.";
            return View("AllMovies", movies);

        }



        public ActionResult Moviedelete(int id, string title, string director)
        {

            MovieDAO dAO = new MovieDAO();
            Movie movies = dAO.getAllMovies();

            Movie MovieToDelete = new Movie(id, title, director);
            dAO.MovieDelete(MovieToDelete);
            movies = dAO.getAllMovies();
            ViewBag.Message = "All movies.";
            return View("AllMovies", movies);

        }

        public ActionResult AllMovies(Movie m, String Save)
        {
            ViewBag.Message = "All movies.";
            MovieDAO dAO = new MovieDAO();
            if (Save == "Save")
            {
                Movie movie = m.Items[m.EditIndex];
                dAO.updateMovie(movie);
                movie.IsEditable = false;
                m.EditIndex = -1;

            }
            m = dAO.getAllMovies();
            return View(m);
        }


        public ActionResult UpdateMovie(Movie m)
        {

            MovieDAO dAO = new MovieDAO();
            dAO.updateMovie(m);
            var movies = dAO.getAllMovies();
            ViewBag.Message = "All movies.";
            return View("AllMovies", movies);
        }

    }
}