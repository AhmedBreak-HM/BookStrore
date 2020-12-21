using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        List<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>()
                {
                    new Author {Id =1 , FullName= "khaled el sadany"},
                    new Author {Id = 2 , FullName= "mohamed audall"},
                    new Author {Id=3 ,FullName="break"}
                };
        }

        public void Add(Author entity)
        {
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.Find( a => a.Id == id);
            return author;
        }

        public IList<Author> list()
        {
            return authors;
        }

        public void Update(int id, Author entity)
        {
            var author = Find(id);
            author.FullName = entity.FullName;
        }
    }
}
