using BookStore.Models;
using System;
using System.Collections.Generic;

namespace BookStore.Repository
{
    public class BookRepository : IRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>
            {
                new Book  {Id = 1,title = "C#", Discrption = "no discrption", author = new Author()},
                new Book {Id= 2 , title="Angular", Discrption= "angular 8 ", author = new Author()},
                new Book {Id = 3 , title="Firebase",Discrption="firebase7", author = new Author()}
            };
        }

        public IList<Book> list()
        {
            return books;
        }

        public Book Find(int id)
        {
            var book = books.Find(b => b.Id == id);
            return book;
        }

        public void Add(Book entity)
        {
            books.Add(entity);
        }

        public void Update(int id, Book entity)
        {
            var book = Find(id);
            book.author = entity.author;
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }
    }
}