using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger_Assignment.EF;
using ZeroHunger_Assignment.EF.Models;

namespace ZeroHunger_Assignment.Controllers
{
    public class NGOController : Controller
    {
        // GET: NGO
        public ActionResult Index()
        {
            ZeroHungerContext db = new ZeroHungerContext();

            return View(db.CollectRequests.Take(10).ToList());
        }


        public ActionResult AddRequest(int id)
        {
            ZeroHungerContext db = new ZeroHungerContext();
            var cr = db.CollectRequests.Find(id);
            List<CollectRequest> cart = null;
            if (Session["cart"] == null)
            {
                cart = new List<CollectRequest>();
            }
            else
            {
                cart = (List<CollectRequest>)Session["cart"];
            }

            cart.Add(new CollectRequest()
            {
                Id=cr.Id,
                StartTime=cr.StartTime,
                EndTime=cr.EndTime,
                Status=cr.Status,
                ResturantId=cr.ResturantId,


             

            });
            Session["cart"] = cart;
            TempData["Msg"] = "Successfully Added";
            return RedirectToAction("Index");



        }

        public ActionResult ShowRequest()
        {

            var cr = (List<CollectRequest>)Session["cart"];
            return View(cr);


        }
    }
}