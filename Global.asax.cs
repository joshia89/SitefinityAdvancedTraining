using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Blogs.Model;
using Telerik.Sitefinity.Data.Events;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.Navigation.Mvc.Models;
using Telerik.Sitefinity.Modules.Blogs;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Initialized += this.Bootstrapper_Initialized;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            EventHub.Unsubscribe<IDataEvent>(this.OnBlogPostCreated);
        }

        private void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
            if (e.CommandName == "Bootstrapped")
            {
                FrontendModule.Current.DependencyResolver.Rebind<INavigationModel>().To<CustomNavigationModel>();
                EventHub.Subscribe<IDataEvent>(this.OnBlogPostCreated);
            }
        }

        private void OnBlogPostCreated(IDataEvent @event)
        {
            if (@event.ItemType == typeof(BlogPost) && @event.Action == "New")
            {
                var blogsManager = BlogsManager.GetManager(@event.ProviderName);
                var currentBlogPost = blogsManager.GetBlogPost(@event.ItemId);

                currentBlogPost.Content = currentBlogPost + "<br/><i>This is the disclaimer!</i>";
            }
        }

    }
}