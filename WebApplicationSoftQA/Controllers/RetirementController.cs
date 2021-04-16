using System.Web.Mvc;
using SoftwareQAProject1;
using WebApplicationSoftQA.Models;

namespace WebApplicationSoftQA.Controllers
{
    public class RetirementController : Controller
    {
        // GET
        public ActionResult Index(RetirementModel retirementModel=null)
        {
            if(retirementModel == null) return View("Retirement", new RetirementModel());
            
            var results = Retirement.CalculateAgeForSavingsGoal
                (retirementModel.Age, retirementModel.Salary, retirementModel.PercentSaved, retirementModel.SavingsGoal);
            var resultsHtml = results.Replace("\n", "<br /><br />");
            var retirement = new RetirementModel(resultsHtml);
            return View("Retirement", retirement);
        }
    }
}