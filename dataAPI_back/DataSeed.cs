using System;
using System.Collections.Generic;
using System.Linq;
using dataAPI_back.Models;


namespace dataAPI_back
{
    // DataSeed with generated data
    public class DataSeed
    {
        private readonly ApiContext _context;

        // constructor for DataSeed
        public DataSeed(ApiContext context) 
        {
            _context = context;
        }

        // private static List<string> states = Helpers.states;

        // populate data (clients, orders, servers)
        public void SeedData(int iNumClients, int iNumOrders)
        {   
            // only if database is empty
            // Clients
            if(!_context.Clients.Any())
            {
                SeedClients(iNumClients);
                // commit changes to database 
                _context.SaveChanges(); 
            }
            // Orders
            if(!_context.Orders.Any())
            {
                SeedOrders(iNumOrders); 
                // SeedOrders(iNumClients);
                // commit changes to database 
                _context.SaveChanges(); 
            }
            // Servers
            if(!_context.Servers.Any())
            {
                // SeedServers(iNumClients); 
                SeedServers(); 
                // commit changes to database 
                _context.SaveChanges();
            }
            
            
        }

        // Servers
        // private void SeedServers(int iNumClients)
        private void SeedServers()
        {
            // List<Server> servers = BuildServerList();
            var servers = BuildServerList();
            
            foreach(var server in servers)
            {
                _context.Add(server);
            }
        }

        // private List<Server> BuildServerList(int iNumSer)
        private List<Server> BuildServerList()
        {
            // list of servers input is manual -> my option
            // like the method we used in the front-end (angular -> dataAPI_front)
            // static list of servers
            return new List<Server>()
            {
                new Server{
                    Id = 1, 
                    Name = "LAMP Server", 
                    IsOnline = true
                },
                new Server{
                    Id = 2, 
                    Name = "HTTP Server", 
                    IsOnline = true
                },
                new Server{
                    Id = 3, 
                    Name = "MQTT Server", 
                    IsOnline = true
                },
                new Server{
                    Id = 4, 
                    Name = "Sensors Server", 
                    IsOnline = true
                },
                new Server{
                    Id = 5, 
                    Name = "SmartSensor01", 
                    IsOnline = false
                },
                new Server{
                    Id = 6, 
                    Name = "SmartSensor02", 
                    IsOnline = false
                },
                new Server{
                    Id = 7, 
                    Name = "dataAPI Server", 
                    IsOnline = true
                },
                new Server{
                    Id = 8, 
                    Name = "Client-A WebServer", 
                    IsOnline = false
                },
                new Server{
                    Id = 10, 
                    Name = "Client-A Services", 
                    IsOnline = true
                },
                new Server{
                    Id = 11, 
                    Name = "Client-B WebServer", 
                    IsOnline = true
                },
                new Server{
                    Id = 12, 
                    Name = "Client-B Services", 
                    IsOnline = false
                }
            };
        }

        // Orders
        private void SeedOrders(int iNumOrders)
        {
            // List<Orders> orders = BuildOrderList(iNumOrders);
            var orders = BuildOrderList(iNumOrders);

            foreach (var order in orders)
            {
                _context.Orders.Add(order);
            }
        }

        private List<Orders> BuildOrderList(int iNumOrders)
        {
            var orders = new List<Orders>();
            var rand = new Random();

            // for(var i = 0; i <= iNumOrders; i++)
            for(var i = 1; i <= iNumOrders; i++)
            {
                // var randClientId = rand.Next(_context.Clients.Count());
                var randClientId = rand.Next(1, _context.Clients.Count());
                var placed = Helpers.GetRandomOrderPlaced();
                var completed = Helpers.GetRandomOrderCompleted(placed);
                var clients = _context.Clients.ToList();

                orders.Add(new Orders{
                    Id = i,
                    // Client = Helpers.GetRandomClient(),
                    // Client = _context.Clients.Where(c => c.Id == randClientId),
                    // Client = _context.Clients.First(c => c.Id == randClientId),
                    Client = clients.First(c => c.Id == randClientId),
                    Total = Helpers.GetRandomOrderTotal(),
                    Placed = placed,
                    Completed = completed
                });
            }

            // return the list of orders
            return orders;
        }


        // Clients
        private void SeedClients(int n)
        {
            // List<Client> clients = BuildClientList(iNumClients);
            var clients = BuildClientList(n);

            foreach (var client in clients)
            {
                _context.Clients.Add(client);
            }
        }

        private List<Client> BuildClientList(int iNumClients)
        {
            var clients = new List<Client>();
            var names = new List<string>();

            // for (var i = 0; i <= iNumClients; i++)
            for (var i = 1; i <= iNumClients; i++)
            {
                var name = Helpers.MakeUniqueClientName(names);
                names.Add(name);

                clients.Add(new Client {
                    Id = i, 
                    Name = name,
                    Email = Helpers.MakeClientEmail(name),
                    State = Helpers.GetRandomState()

                });
            } 
            return clients;
        }

    }
}