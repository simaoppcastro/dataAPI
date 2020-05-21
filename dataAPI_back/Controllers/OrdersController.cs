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

            var totalCount = data.Count();
            // https://docs.microsoft.com/en-us/dotnet/api/system.math.ceiling?view=netcore-3.1
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            // response
            var response = new 
            {
                // PaginatedResponse
                Page = page,
                TotalPages = totalPages 
            };

            // http 200 status response with the response
            // return Ok response
            return Ok(response);
        }

        // display orders by state
        // state => city example
        [HttpGet("ByState")]
        public IActionResult ByState()
        {
            var _orders = _context.Orders.Include(o => o.Client).ToList();

            var groupedResult = _orders.GroupBy(o => o.Client.State)
                .ToList()
                .Select(g => new
                {
                    State = g.Key,
                    Total = g.Sum(x => x.Total)
                }).OrderByDescending(res => res.Total)
                    .ToList();

            // return the group result            
            return Ok(groupedResult);
        }

        // display orders by client
        [HttpGet("ByClient/{n}")]
        // n => max number of clients
        // usage example -> grab the top 10 clients
        public IActionResult ByClient(int m)
        {
            var _orders = _context.Orders.Include(o => o.Client).ToList();

            var groupedResult = _orders.GroupBy(o => o.Client.Id)
                .ToList()
                .Select(g => new
                {
                    Name = _context.Clients.Find(g.Key).Name,
                    Total = g.Sum(x => x.Total)
                }).OrderByDescending(res => res.Total)
                    .Take(m)
                    .ToList();

            // return the group result            
            return Ok(groupedResult);
        }

        [HttpGet("GetOrder/{}", Name = "GetOrder")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Orders
                .Include(o => o.Client)
                .First(t => t.Id == id);
            return Ok(order);   
        }

    }   
}