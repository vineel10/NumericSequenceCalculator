using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericSequenceCalculator;
using NumericSequenceCalculator.Web.Controllers;
using NumericSequenceCalculator.Web.Helpers;
using NumericSequenceCalculator.Web.Models;

namespace NumericSequenceCalculator.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual(result.ViewName, "Calculate");
        }

        [TestMethod]
        public void Calculate()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Calculate() as ViewResult;
            Assert.AreEqual(result.ViewName, "Calculate");
        }

        [TestMethod]
        public void CalculateSequenceWithInvalidModel()
        {
            
            HomeController controller = new HomeController();
            var model = new SequenceNumberBindingModel()
            {
                Number = 0,
                SequenceTypeId = 0
            };
            ViewResult result = controller.Calculate(model) as ViewResult;
            Assert.IsNull(result.ViewData["Results"]);

            model = new SequenceNumberBindingModel()
            {
                Number = -10,
                SequenceTypeId = 0
            };
            
            result = controller.Calculate(model) as ViewResult;
            Assert.IsNull(result.ViewData["Results"]);
        }

        [TestMethod]
        public void CalculateSequenceValidModelForAllSequenceTypes()
        {
            
            HomeController controller = new HomeController();
            var model = new SequenceNumberBindingModel()
            {
                Number = 10,
                SequenceTypeId = 0
            };
            
            var result = controller.Calculate(model) as ViewResult;
            Assert.IsInstanceOfType(result.ViewData["Results"], typeof(Dictionary<long, List<double>>));
        }

        [TestMethod]
        public void CalculateSequenceValidModelForSequenceType()
        {
            HomeController controller = new HomeController();
            var model = new SequenceNumberBindingModel()
            {
                Number = 10,
                SequenceTypeId = SequenceType.AllEvenNumbersSequenceType.Id
            };
            var result = controller.Calculate(model) as ViewResult;
            Assert.IsInstanceOfType(result.ViewData["Results"], typeof(Dictionary<long, List<double>>));
            Assert.IsTrue(((Dictionary<long, List<double>>) result.ViewData["Results"]).Count == 1);
        }

    }
}
