using restaurantRater.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace restaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        //GET: Restaurant
        //This is an object
        private RestaurantDBContext db = new RestaurantDBContext();
        
        // GET: Restaurants
        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Restaurant/Create
        //Sends data to be saved to the database
        [HttpPost]//this is an attribute - [] above method
        [ValidateAntiForgeryToken]//protects fields from being used to pull data out of database
        
        //This method (below) will run once "Create" button is pressed
        public ActionResult Create([Bind(Include = "RestaurantID,Name,Address,Rating")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
            //if form is not valid, you will return back to "create" page with entered data
            //and error message showing which part of the form is invalid
        }

        //GET: Restaurant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //POST: Restaurants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantID,Name,Address,Rating")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //GET: Restaurant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}