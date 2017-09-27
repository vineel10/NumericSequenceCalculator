using NumericSequenceCalculator.Web.Helpers;
using NumericSequenceCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NumericSequenceCalculator.Web.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {   
            return View("Calculate");
        }

        public ActionResult Calculate()
        {
            return View("Calculate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(SequenceNumberBindingModel model)
        {
            return !ModelState.IsValid ? View(model) : InitiateNumericSequence(model);
        }

        public ActionResult InitiateNumericSequence(SequenceNumberBindingModel model)
        {
            if (model.Number > 0)
            {
                var result = new Dictionary<long, List<double>>();
                if (model.SequenceTypeId == 0)
                {
                    foreach (var type in SequenceType.All)
                        result.Add(type.Id, type.Calculate?.Invoke(model.Number));
                }
                else
                {
                    var sequenceType = SequenceType.All.FirstOrDefault(f => f.Id == model.SequenceTypeId);
                    if (sequenceType?.Calculate != null)
                        result.Add(sequenceType.Id, sequenceType.Calculate.Invoke(model.Number));
                }
                ViewData["Results"] = result;
            }
            else
                ViewData["Results"] = null;
            return View("Calculate", model );
        }
    }
}