using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace miPrimerProyecto.Models
{
    public class BaseModelo
    {
        public int ActualPage { get; set; }
        public int total { get; set; }
        public int recortPage { get; set; }
        public RouteValueDictionary ValuesQueryString { get; set; }


    }
}