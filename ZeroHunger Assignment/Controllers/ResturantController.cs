using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger_Assignment.EF.Models;
using ZeroHunger_Assignment.EF;



namespace ZeroHunger_Assignment.Controllers
{
    public class ResturantController : Controller
    {
        // GET: Resturant

        public ActionResult FoodView()
        {
            ZeroHungerContext db = new ZeroHungerContext();

            return View(db.FoodItems.Take(10).ToList());
        }


        public ActionResult AddRequest(int id)
        {
            ZeroHungerContext db = new ZeroHungerContext();
            var fi = db.FoodItems.Find(id);
            List<FoodItem> cart = null;
            if (Session["cart"] == null)
            {
                cart = new List<FoodItem>();
            }
            else
            {
                cart = (List<FoodItem>)Session["cart"];
            }

            cart.Add(new FoodItem()
            {
                Id = fi.Id,
                Name = fi.Name,
                Quantity = 1,
                CollectRequestId = fi.CollectRequestId,

            });
            Session["cart"] = cart;
            TempData["Msg"] = "Successfully Added";
            return RedirectToAction("FoodView");



        }
        public ActionResult ShowRequest()
        {

            var fooditems = (List<FoodItem>)Session["cart"];
            return View(fooditems);


        }


         public ActionResult Place()
          {
            var foodItems = (List<FoodItem>)Session["cart"];
            ZeroHungerContext db = new ZeroHungerContext();

            foreach (var f in foodItems)
            {
                CollectRequest cr = new CollectRequest();

                cr.StartTime = DateTime.Now;
                cr.EndTime = DateTime.Now.AddDays(1);
                cr.Status = "Pending";
            }

                db.SaveChanges();
                TempData["Msg"] = "Placed Successfully";
                return RedirectToAction("FoodView");
        }
    }
}