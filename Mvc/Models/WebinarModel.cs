using System;
using System.Linq;

namespace SitefinityWebApp.Mvc.Models
{
    public class WebinarModel
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Title { get; set; }
        public string description { get; set; }
        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}