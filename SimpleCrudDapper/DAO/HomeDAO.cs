using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCrudDapper.Models;
using SimpleCrudDapper.Utility;

namespace SimpleCrudDapper.DAO
{
    public class HomeDAO
    {
        private DbContext context;
        public HomeDAO()
        {
            context = new DbContext();
        }

        public List<object> GetAllData()
        {
            var query = "SELECT B.*, G.genre FROM book B LEFT JOIN ref_genre G ON G.id = B.ref_genre_id";
            var param = new { };

            using (var connection = context.CreateConnection1())
            {
                try
                {
                    var data = connection.Query(query,param).ToList();
                    return data;
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return new List<object>();
                }
            }
        }

        public List<SelectListItem> GetAllGenres()
        {
            var query = "Select id Value, genre TEXT from ref_genre";
            var param = new { };

            using (var connection = context.CreateConnection1())
            {
                try
                {
                    var data = connection.Query<SelectListItem>(query).ToList();
                    return data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return new List<SelectListItem>();
                }
            }
        }

        public DbResponse InsertBook(BookViewModel book)
        {
            var query = "INSERT INTO book (title, author, publisher, year, ref_genre_id) VALUES (@title, @author, @publisher, @year, @ref_genre_id)";
            var param = new { };

            using (var connection = context.CreateConnection1())
            {
                try
                {
                    var data = connection.Execute(query, book);
                    return new DbResponse
                    {
                        data = data,
                        response = "Ok",
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return new DbResponse { 
                        response = "Error",
                        desciption = ex.ToString()
                    };
                }
            }
        }

        public BookViewModel GetDataById(int id)
        {
            var query = "SELECT * FROM book WHERE id = @BOOK_ID";
            var param = new { BOOK_ID = id };

            using (var connection = context.CreateConnection1())
            {
                try
                {
                    var data = connection.QueryFirstOrDefault<BookViewModel>(query, param);
                    return data;
                }
                catch (Exception ex)
                {
                    return new BookViewModel();
                }
            }
        }

        public DbResponse UpdateBook(BookViewModel book)
        {
            var query = "UPDATE book SET title = @title, author = @author, publisher = @publisher, ref_genre_id = @ref_genre_id, year = @year WHERE id = @id";

            using (var connection = context.CreateConnection1())
            {
                try
                {
                    var data = connection.Execute(query, book);
                    return new DbResponse
                    {
                        data = data,
                        response = "Ok",
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return new DbResponse
                    {
                        response = "Error",
                        desciption = ex.ToString()
                    };
                }
            }
        }

        public DbResponse DeleteBook(int id)
        {
            var query = "DELETE book WHERE id = @BOOK_ID";

            using (var connection = context.CreateConnection1())
            {
                try
                {
                    var data = connection.Execute(query, new { BOOK_ID = id });
                    return new DbResponse
                    {
                        data = data,
                        response = "Ok",
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return new DbResponse
                    {
                        response = "Error",
                        desciption = ex.ToString()
                    };
                }
            }
        }
    }
}
