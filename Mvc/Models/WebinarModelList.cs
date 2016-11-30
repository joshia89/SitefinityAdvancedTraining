using System;
using System.Collections.Generic;
using System.Linq;

namespace SitefinityWebApp.Mvc.Models
{
    public class WebinarModelList
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>

        private List<WebinarModel> webinarModel = new List<WebinarModel>();
        public List<WebinarModel> WebinarModel { get; set; }        
    }
}