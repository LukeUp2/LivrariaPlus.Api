using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Communication.Responses;
using LivrariaPlus.Api.Models;

namespace LivrariaPlus.Api.Extensions.EntityToDTO
{
    public static class BookExtension
    {
        public static BookResponseJson ToResponseJson(this Book book)
        {
            return new BookResponseJson
            {
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                Genre = book.Genre,
                Stock = book.Stock
            };
        }
    }
}