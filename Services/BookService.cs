using System.Collections.Generic;
using System.Collections;
using BookApi.Models;
using BookApi.Repository;


namespace  BookApi.Services {
    public class BookService : IBookService {
        
        private IBookRepository _repo;
        
        public BookService(IBookRepository repo) {
            _repo = repo;
        }

        
        public IEnumerable<Book> GetBooks() {
            IEnumerable<Book> myList = _repo.GetBooks();
            return myList;
        }

        public Book GetBooksByTitle(string title) {
            return _repo.GetBookByTitle(title);
        }
/*        public Book GetBookssByGenre(string genre) {
            IEnumerable<Book> myList = _repo.GetBooks();
            foreach (Book b in myList) {
                if(b.Genre==genre)
                    return b;

            }
            return null;
        }*/

        public void CreateBook(Book b) {
            _repo.InsertBook(b);
        }

        public void UpdateBook(string title, Book b) {
            _repo.UpdateBook(title, b);
        }

        public void DeleteBook(string title) {
            _repo.DeleteBook(title);
        }



    }
}