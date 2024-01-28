using System.Collections.Generic;
using System.Data;
using BookApi.Models;

namespace BookApi.Services {
    public interface IBookService {
        public IEnumerable<Book> GetBooks();
        public Book GetBooksByTitle(string title);
        //public Book GetBooksByGenre(string genre);
        public void CreateBook(Book b);
        public void UpdateBook(string title, Book b);
        public void DeleteBook(string title);

    }
}