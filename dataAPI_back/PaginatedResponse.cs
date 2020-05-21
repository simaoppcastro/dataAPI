using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace dataAPI_back
{
    // generic method -> T
    // https://developer.wordpress.org/rest-api/using-the-rest-api/pagination/
    public class PaginatedResponse<T>
    {
        // i -> pageIndex; l -> pageSize
        // example1 => [1] page, 10 results => (1-1)*10 => skip 0 => take 10 from the dataset => to a list
        // example2 => [2] page, 100 results => (2-1)*100 => skip 100 => take 100 from the dataset => to a list
        public PaginatedResponse(IEnumerable<T> data, int i, int l)
        {   
            // skip some data
            Data = data.Skip((i -1) * l).Take(l).ToList();
            TotalObjects = data.Count();
        }

        public int TotalObjects{get; set;}
        public IEnumerable<T> Data {get; set;}
        
    }  
}