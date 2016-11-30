using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using SitefinityWebApp.Mvc.Models;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Model;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Webinar", Title = "Webinar", SectionName = "MvcWidgets")]
    
    public class WebinarController : Controller
    {
        private WebinarModel model;
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual WebinarModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = ControllerModelFactory.GetModel<WebinarModel>(this.GetType());

                return this.model;
            }
        }

        public string ItemType
        {
            get
            {
                return this.itemType;
            }

            set
            {
                this.itemType = value;
            }
        }

        string itemType = "Telerik.Sitefinity.DynamicTypes.Model.Webinars.Webinar";

        public string sample { get; set; }
        public string SelectedItem
        {
            get; set;
        }

        /// <summary>
        /// This is the default Action.
        /// </summary>
        public ActionResult Index()
        {
            var model = new WebinarModel();
            

            var providerName = String.Empty;

            // Set a transaction name
            var transactionName = "someTransactionName";

            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager(providerName, transactionName);
            Type webinarType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Webinars.Webinar");            
            
            var myCollection = dynamicModuleManager.GetDataItems(webinarType).FirstOrDefault();
            
            model.Title = myCollection.GetValue("Title").ToString();
            model.description = myCollection.GetValue("Description").ToString(); 
            model.StartTime = Convert.ToDateTime(myCollection.GetValue("StartTime"));
            model.EndTime = Convert.ToDateTime(myCollection.GetValue("EndTime"));
            return View("Default", model);
        }
        
                  
    }
}