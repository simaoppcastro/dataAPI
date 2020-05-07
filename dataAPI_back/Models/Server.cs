using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataAPI_back.Models
{
    public class Server
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
    }
}
