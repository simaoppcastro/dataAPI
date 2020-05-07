using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dataAPI_back.Models
{
    public class ApiContext : DbContext
    {
        // constructor
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        // 3 tables -> for each entety model
        public DbSet<Client> Clients { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Server> Servers { get; set; }
    }
}
