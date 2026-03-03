using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Communication.Requests;
using LivrariaPlus.Api.Communication.Responses;
using LivrariaPlus.Api.Models;

namespace LivrariaPlus.Api.Extensions
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

        public static Book ToEntity(this CreateBookRequestJson request)
        {
            return new Book
            {
                Title = request.Title,
                Author = request.Author,
                Price = request.Price,
                Genre = request.Genre,
                Stock = request.Stock
            };
        }
    }
}