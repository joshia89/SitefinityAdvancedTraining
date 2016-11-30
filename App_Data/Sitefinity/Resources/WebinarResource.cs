using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using SitefinityWebApp.Mvc.Models;
using Telerik.Sitefinity.Localization;

namespace SitefinityWebApp.App_Data.Sitefinity.Resources
{
    
    public class WebinarResource : Resource
    {
        [ResourceEntry("StaticMessage", Value = "This is the static message", Description = "Static message on the BreakingNews view.", LastModified = "2016/07/12")]
        public string StaticMessage { get; set; }
    }
}