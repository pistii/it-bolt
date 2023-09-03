using System;
using System.Collections.Generic;

namespace ItBolt.Model.DTOs
{
    public class TableDTO<T>
    {
        public TableDTO(List<T>? data, int totalItems)
        {
            TotalItems = totalItems;
            Data = data;
        }


        public int TotalItems { get; set; }

        public List<T>? Data { get; set; }
    }
}
