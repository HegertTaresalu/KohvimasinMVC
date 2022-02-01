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
        public int JoogiKogus { get; set; } = 0;
        public int Jookepakis = 50;
        public int Topsikogus { get; set; } = 0;
        public int Topsepakis = 50;
        public int Topsejuua { get; set; }
    }
}
