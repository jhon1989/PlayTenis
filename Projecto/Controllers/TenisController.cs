using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projecto.Controllers
{
    public class TenisController : Controller
    {
        // GET: Tenis
        public ActionResult Index()
        {
            Models.TenisVieModel tenisVieModel = new Models.TenisVieModel();
            tenisVieModel.resultPoint = "0 - 0 ";
            return View(tenisVieModel);
        }

        public ActionResult Point(int palyers, string resultPoint, int consecutivePointPlayer1, int consecutivePointPlayer2)
        {
            Services.Tennis tennis = new Services.Tennis();
            return View("Index", tennis.setPoint(palyers, resultPoint, consecutivePointPlayer1, consecutivePointPlayer2));
        }

        public ActionResult Restart()
        {
            Models.TenisVieModel tenisVieModel = new Models.TenisVieModel();
            return RedirectToAction("Index");
        }
    }
}