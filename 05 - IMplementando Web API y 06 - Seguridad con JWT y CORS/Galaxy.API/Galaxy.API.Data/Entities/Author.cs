using System;
using System.Collections.Generic;

namespace Galaxy.API.Data.Entities
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public Guid Id { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string Genre { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset? DateOfDeath { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}