using BookstoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookstoreAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBooksbyidAsync(int bookId);
        Task<int> AddBookAsync(Book books);
        Task UpdateBookAsync(int BookId, Book books);

        Task UpdateBookPatchAsync(int BookId, JsonPatchDocument books);

        Task DeleteBookAsync(int Bookid);
    }
}
