using System;
using System.Collections.Generic;
using System.Data;
using BookApi.Models;
using MySql.Data.MySqlClient;


namespace BookApi.Repository {
    public class BookRepository : IBookRepository {
        private static readonly List<Book> books = new List<Book>() 
        {
            new Book {Title="Divergent", Author = "Roth", Genre="Action", ReleaseYear=2011},
            
        };
        private MySqlConnection _connection;

        public BookRepository() {
            string connectionString="server=localhost;user=csci495bookuser;password=csci495bookpass;database=books";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
            
        }

        ~BookRepository() {
            _connection.Close();
        }

        public IEnumerable<Book> GetBooks() {
            var statement = "Select * from Books";
            var command = new MySqlCommand(statement,_connection);
            var results = command.ExecuteReader();

            List<Book> newList = new List<Book>(20);

            while(results.Read()){
                Book b = new Book {
                    Title = (string)results[0],
                    ReleaseYear = (int)results[1],
                    Author = (string)results[2],
                    Genre = (string)results[3]
                };
                newList.Add(b);
            }
            results.Close();
            return newList;
            
        }

        public Book GetBookByTitle(string title) {
            var statement = "Select * From Books Where Title = @newTitle";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newTitle", title);

            var results = command.ExecuteReader();
            Book b = null;
            if (results.Read()) {
                b = new Book {
                    Title = (string)results[0],
                    ReleaseYear = (int)results[1],
                    Genre = (string)results[3],
                    Author = (string)results[2]
                };
            }
            results.Close();
            return b;
            
        }

        public void InsertBook(Book b) {
            
            var statement = "Insert Into Books (Title, ReleaseYear, Genre, Author) Values (@t, @ry, @g, @a)";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@t", b.Title);
            command.Parameters.AddWithValue("@ry", b.ReleaseYear);
            command.Parameters.AddWithValue("@g", b.Genre);
            command.Parameters.AddWithValue("@a", b.Genre);


            int result = command.ExecuteNonQuery();
            Console.WriteLine(result);
        }

        public void UpdateBook(string title, Book bookIn) {
            var statement = "Update Books Set Title=@newTitle, ReleaseYear=@newReleaseYear, Genre=@newGenre, Author=@newAuthor Where Title=@updateTitle";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newTitle", bookIn.Title);
            command.Parameters.AddWithValue("@newReleaseYear", bookIn.ReleaseYear);
            command.Parameters.AddWithValue("@newGenre", bookIn.Genre);
            command.Parameters.AddWithValue("@newAuthor", bookIn.Author);
            command.Parameters.AddWithValue("@updateTitle", title);

            Console.WriteLine(bookIn);
            int result = command.ExecuteNonQuery();
            Console.WriteLine(result);
        }

        /*public void DeleteBook(string title) {
            foreach(Book b in books) {
                if(b.Title.Equals(title)) {
                    books.Remove(b);
                    return;
                }
            };
        }*/

        public bool DeleteBook(string title) {
            var statement = "DELETE FROM Books WHERE Title=@newTitle";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newTitle", title);

            int result = command.ExecuteNonQuery();
            //result.Close();
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}