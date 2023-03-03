using System;
using System.Collections.Generic;

namespace ItBolt.Model.DTOs
{
    public class TableDTO<T>
    {
        public TableDTO(int totalItems, List<T>? data)
        {
            TotalItems = totalItems;
            Data = data;
        }

        public int TotalItems { get; set; }

        public List<T>? Data { get; set; }
    }
}
