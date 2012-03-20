using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace QX.GPS
{
    public class Location
    {
               /// <summary>
        /// latitude
        /// </summary>
        private string _latitude = "";

        /// <summary>
        /// longtitude
        /// </summary>
        private string _longtitude = "";

        /// <summary>
        /// default constructor
        /// </summary>
        public Location()
         {

         }

        /// <summary>
        /// construct geo given latitude and longtitude
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longtitude"></param>
        public Location(string latitude, string longtitude)
         {
             _latitude = latitude;
             _longtitude = longtitude;
         }
        
        /// <summary>
        /// construct geo given name of a place
        /// </summary>
        /// <param name="location"></param>
        public Location(string location)
         {
            string output = "csv";
            string url = string.Format("http://maps.google.com/maps/geo?q={0}&output={1}", location, output);
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
             HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
             {
                string[] tmpArray = sr.ReadToEnd().Split(',');
                 _latitude = tmpArray[2];
                 _longtitude = tmpArray[3];
             }
         }

        /// <summary>
        /// get latitude(纬度)
        /// </summary>
        public string Latitude
         {
            get { return _latitude; }
            set { _latitude = value; }
         }

        /// <summary>
        /// get longtitude(经度)
        /// </summary>
        public string Longtitude
         {
            get { return _longtitude; }
            set { _longtitude = value; }
         }
    }
}
