﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Web.App
{
    public class OrderItemModel
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }
    }
}
