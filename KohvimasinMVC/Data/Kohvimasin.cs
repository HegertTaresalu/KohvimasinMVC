using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KohvimasinMVC.Data
{
    public class Kohvimasin
    {
        public int Id { get; set; }
        public string Jooginimi { get; set; }
        public int Topsepakis { get; set; }
        public int Topsejuua { get; set; }
    }
}
