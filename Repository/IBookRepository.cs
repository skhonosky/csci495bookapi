using System.Collections.Generic;
using BookApi.Models;

namespace BookApi.Repository {
    public interface IBookRepository {
        public IEnumerable<Book> GetBooks();
        public Book GetBookByTitle(string title);
        //public Book GetBooksByGenre(string genre);
        public void InsertBook(Book b);
        public void UpdateBook(string title, Book bookIn);
        // public void DeleteBook(string title);
        public bool DeleteBook(string title);
    }
}