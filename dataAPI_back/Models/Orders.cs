using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAPI.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public decimal Total { get; set; }
        public DateTime Placed { get; set; }
        public DateTime? Completed { get; set; }
    }
}
