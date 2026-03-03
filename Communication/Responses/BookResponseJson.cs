using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Enuns;

namespace LivrariaPlus.Api.Communication.Responses
{
    public class BookResponseJson
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public BookGenre Genre { get; set; }
    }
}