
using BookstoreAPI.Data;
using BookstoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;
using System.Net;

namespace BookstoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly Bookstorecontext _context;
        private readonly IMapper _mapper;

        public BookRepository(Bookstorecontext context ,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Book>> GetAllBooksAsync()
        {
            //var records = await _context.Books.Select(x => new Book()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).ToListAsync();

            //return records;
            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<Book>>(records);
           

        }

        public async Task<Book> GetBooksbyidAsync(int bookId)
        {
            //var records = await _context.Books.Where(x => x.Id == bookId).Select(x => new Book()
            //{
             //   Id = x.Id,
             //   Title = x.Title,
             //   Description = x.Description,
            //}).FirstOrDefaultAsync();
           // #pragma warning disable CS8603 // Possible null reference return.
            //return records;
            //#pragma warning restore CS8603 // Possible null reference return.

            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<Book>(book);
        }

        public async Task<int> AddBookAsync(Book books)
        {
            var book = new Book()
            {
                Title = books.Title,
                Description = books.Description,

            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
        public async Task UpdateBookAsync(int BookId, Book books)
        {
            //var book = await _context.Books.FindAsync(BookId);
            //if (book != null)
            //{
            //   book.Title = books.Title;
            //   book.Description = books.Description;
            //    await _context.SaveChangesAsync();
            //}

            var book = new Book()
            {
                Id = BookId,
                Title = books.Title,
                Description = books.Description,

            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBookPatchAsync(int BookId, JsonPatchDocument books)
        {
            var book = await _context.Books.FindAsync(BookId);
            if(book != null)
            {
                books.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteBookAsync(int Bookid)
        {
            var book =  new Book() { Id = Bookid };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
