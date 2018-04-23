using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridViewTooltip.Models
{
    public class SimpleModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        const string descriptionString = @"With DevExpress web controls, you can build a bridge to the future on the platform you know and love. 
          The 175+ AJAX controls and MVC extensions that make up the DevExpress ASP.NET Subscription have been engineered so you can deliver exceptional, touch-enabled, interactive experiences for the web, regardless of the target browser or computing device. 
DevExpress web UI components support all major browsers including Internet Explorer, FireFox, Chrome, Safari and Opera, and are continuously tested to ensure the best possible compatibility across platforms, operating systems and devices.    
     And to ensure you can build your best and meet the needs of your enterprise each and every time, the DevExpress ASP.NET Subscription ships with 0 built-in application themes that can be used out-of-the box or customized via our ASP.NET Theme Builder";
        public static List<SimpleModel> GetData()
        {
            List<SimpleModel> l = HttpContext.Current.Session["data"] as List<SimpleModel>;
            if (l == null)
            {
                l = new List<SimpleModel>();
                for (int i = 0; i < 100; i++)
                {
                    l.Add(new SimpleModel()
                    {
                        ID = i,
                        Name = "ItemName " + i,
                        Description = descriptionString
                    });
                }
            }
            return l;
        }
    }
}