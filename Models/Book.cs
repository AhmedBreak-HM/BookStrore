﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string Discrption { get; set; }
        public Author author { get; set; }

    }
}
