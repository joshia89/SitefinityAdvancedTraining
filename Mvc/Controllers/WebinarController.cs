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
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using SitefinityWebApp.App_Data.Sitefinity.Resources;
using System.Collections.Generic;
using Telerik.Sitefinity.Modules.Events;
using Telerik.Sitefinity.Data.ContentLinks;

namespace SitefinityWebApp.Mvc.Controllers
{

    [ControllerToolboxItem(Name = "Webinar", Title = "Webinar", SectionName = "MvcWidgets")]
    [Localization(typeof(SitefinityWebApp.App_Data.Sitefinity.Resources.WebinarResource))]
    public class WebinarController : Controller
    {
        private WebinarModelList model;
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual WebinarModelList Model
        {
            get
            {
                if (this.model == null)
                    this.model = ControllerModelFactory.GetModel<WebinarModelList>(this.GetType());

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
            var model = new WebinarModelList();
            

            var providerName = String.Empty;

            // Set a transaction name
            var transactionName = "someTransactionName";

            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager(providerName, transactionName);
            Type webinarType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Webinars.Webinar");

            // trying out the join
            var contentLinksManager = ContentLinksManager.GetManager();
            var links = contentLinksManager.GetContentLinks()
            .Where(cl => cl.ParentItemType == typeof(WebinarModel).FullName &&
            cl.ComponentPropertyName == "RelatedEvent");            var webinars = dynamicModuleManager.GetDataItems(webinarType);
            var eventsManager = EventsManager.GetManager();
            var events = eventsManager.GetEvents();
            var relatedData = events
            .Join(links, (bp) => bp.OriginalContentId, (cl) => cl.ChildItemId, (bp, cl) => new {
                bp,
                cl
            })
            .Join(webinars, (bpcl) => bpcl.cl.ParentItemId, (n) => n.OriginalContentId, (bpcl, n) => new {
                n,
                bpcl.bp
            }).Select(x => new WebinarModel() { Title = x.n.GetString("Title"), description = x.n.GetString("Description"), EventId = x.bp.Id.ToString() }).ToList();
            

            //passing back the collection (before performance optimizations)
            //List<WebinarModel> myCollection = dynamicModuleManager.GetDataItems(webinarType).Select(x => new WebinarModel()
            //{
            //    Title = x.GetValue("Title").ToString(),
            //    description = x.GetValue("Description").ToString(),
            //    StartTime = Convert.ToDateTime(x.GetValue("StartTime")),
            //    EndTime = Convert.ToDateTime(x.GetValue("EndTime")),
            //    EventId = EventsManager.GetManager().GetEvents().Where(e => e.Title == x.GetValue("Title").ToString()).Select(y => y.Id).ToString()                
            //}).ToList();            

            return View("Default", relatedData);
        }
        
                  
    }
}