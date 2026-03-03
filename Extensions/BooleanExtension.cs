using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaPlus.Api.Models;

namespace LivrariaPlus.Api.Extensions
{
    public static class BooleanExtension
    {
        public static bool IsFalse(this bool value) => !value;
    }
}