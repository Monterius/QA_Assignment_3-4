using System.Web;
using System.Web.Mvc;
using SoftwareQAProject1;
using WebApplicationSoftQA.Models;

namespace WebApplicationSoftQA.Controllers
{
    public class BmiController : Controller
    {
        public ActionResult Index(BmiModel bmiModel=null)
        {
            if (bmiModel == null) return View("BodyMassIndex", new BmiModel());
            
            var results = BodyMassIndex.Calculate(bmiModel.Height, bmiModel.Weight);
            var resultsHtml = results.Replace("\n", "<br /><br />");
            var bmi = new BmiModel(resultsHtml);
            return View("BodyMassIndex", bmi);
        }
    }
}