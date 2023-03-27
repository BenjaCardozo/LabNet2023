using System;
using System.Collections.Generic;

namespace Northwind.MVC.Models
{
    public class PersonajesViewModel
    {        
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public LocationOriginViewModel origin { get; set; }
        public LocationOriginViewModel location { get; set; }
        public string image { get; set; }
        public List<string> episode { get; set; }
        public string url { get; set; }
        public DateTime created { get; set; }
    }
}