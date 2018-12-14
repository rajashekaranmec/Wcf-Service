using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCF_Client.Controllers
{
    public class CalculatorClientController : Controller
    {
        // GET: CalculatorClient
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Calculate(FormCollection collection, string Sum, string Subtract)
        {
            CalculatorServiceReference.CalculatorServiceClient Client = new CalculatorServiceReference.CalculatorServiceClient("BasicHttpBinding_ICalculatorService");
            if (!string.IsNullOrEmpty(Sum))
            {
                ViewBag.Message = Client.sum(Convert.ToInt32(collection["Number1"]), Convert.ToInt32(collection["Number2"]));
            }
            if (!string.IsNullOrEmpty(Subtract))
            {
                ViewBag.Message = Client.Subtract(Convert.ToInt32(collection["Number1"]), Convert.ToInt32(collection["Number2"]));
            }
            return View("Index");
        }
    }
}