using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models;

namespace SitefinityWebApp.Mvc.Models
{
    public class CustomNavigationViewModel : NodeViewModel
    {
        public CustomNavigationViewModel() : base()
        {
            this.Rating = this.GetRating();
        }

        public CustomNavigationViewModel(SiteMapNode node, string url, string target, bool isCurrentlyOpened, bool hasChildOpen) : base(node, url, target, isCurrentlyOpened, hasChildOpen)
         {
            this.Rating = this.GetRating();
        }

        public string Rating
        {
            get
            {
                return Rating;
            }

            set { }
        }

        private string GetRating()
        {
            var pageNode = this.OriginalSiteMapNode as Telerik.Sitefinity.Web.PageSiteNode;
            if (pageNode != null)
            {
                var rating = pageNode.GetCustomFieldValue("Rating");
                return rating.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}