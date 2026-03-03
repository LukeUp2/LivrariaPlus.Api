using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaPlus.Api.Data.Repositories
{
    public class BookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _dbContext.Books.AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _dbContext.Books.Update(book);
        }

        public async void DeleteAsync(Guid id)
        {
            var book = await GetByIdAsync(id);

            if (book is not null)
            {
                _dbContext.Books.Remove(book);
            }
        }
    }
}