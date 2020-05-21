using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dataAPI_back.Models;

namespace dataAPI_back.Controllers
{
    [Route("api/[controller]")]

    public class OrdersController : Controller
    {
        private readonly ApiContext _context;

        // constructor with dependency injection
        public OrdersController(ApiContext context)
        {
            _context = context;
        }

        // some routes
        
        // specify the current page that the user want and the size of the page
        // GET api/orders/pageNumber/pageSize
        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public IActionResult Get(int pageIndex, int pageSize)
        {   
            // most recents orders
            // Include -> entety framework
            var data = _context.Orders.Include(o => o.Client).OrderByDescending(c => c.Placed);
            
            // after getting the "raw" data - specified the data in pages and sizes to display this orders
            var page = new PaginatedResponse<Orders>(data, pageIndex, pageSize);

            // return Ok response
            return Ok();
        }


    }   
}