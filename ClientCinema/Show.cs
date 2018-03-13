using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCinema
{
    public class Show
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string time { get; set; }
        public string timeH => time.Replace("T", " ");
    }
}
