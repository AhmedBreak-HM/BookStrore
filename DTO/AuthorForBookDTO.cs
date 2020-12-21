using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DTO
{
    public class AuthorForBookDTO
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string Discrption { get; set; }
        public int AuthorId { get; set; }
        public List<Author> authors { get; set; }
    }
}
