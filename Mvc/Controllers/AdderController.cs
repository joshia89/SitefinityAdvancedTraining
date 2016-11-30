using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using SitefinityWebApp.Mvc.Models;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Adder", Title = "Adder", SectionName = "MvcWidgets")]
    public class AdderController : Controller
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [Category("integer Properties")]
        public int Number1 { get; set; }

        public int Number2 { get; set; }

        /// <summary>
        /// This is the default Action.
        /// </summary>
        /// 

        private AdderModel model;        
        public AdderModel Model
        {
            get
            {
                return new AdderModel();
            }
        }
        public ActionResult Index()
        {
            AdderModel adderModel = new AdderModel();
            adderModel.Number1 = this.Number1;
            adderModel.Number2 = this.Number2;
            var total = adderModel.Number1 + adderModel.Number2;
            adderModel.Total = total;

            return View("Default", adderModel);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}