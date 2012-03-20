using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.Model;
using QX.BLL;
using System.Web.Mvc;

namespace QX.GPS
{
    public static class GPSHelper
    {
        public static string InitGPS(this HtmlHelper hepler)
        {
            TagBuilder builder = new TagBuilder("script");
            var GAPI = System.Configuration.ConfigurationSettings.AppSettings["GMapAPI"].ToString();
            string src = string.Format("http://ditu.google.cn/maps?file=api&amp;v=2&amp;key={0}&sensor=true",GAPI);
            builder.MergeAttribute("src", src);
            return builder.ToString(TagRenderMode.Normal);            
        }
    }
}
