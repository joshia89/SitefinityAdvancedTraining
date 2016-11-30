using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models
{
    public class WebinarModel
    {
        public string Title { get; set; }
        public string description { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EventId { get; set; }
    }
}