using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LivrariaPlus.Api.Enuns
{
    public enum BookGenre
    {
        [EnumMember(Value = "Fiction")]
        Fiction,

        [EnumMember(Value = "Non-Fiction")]
        NonFiction,

        [EnumMember(Value = "Fantasy")]
        Fantasy,

        [EnumMember(Value = "Science Fiction")]
        ScienceFiction,

        [EnumMember(Value = "Mystery")]
        Mystery,

        [EnumMember(Value = "Thriller")]
        Thriller,

        [EnumMember(Value = "Romance")]
        Romance,

        [EnumMember(Value = "Horror")]
        Horror,

        [EnumMember(Value = "Biography")]
        Biography,

        [EnumMember(Value = "History")]
        History,

        [EnumMember(Value = "Self-Help")]
        SelfHelp,

        [EnumMember(Value = "Poetry")]
        Poetry
    }
}