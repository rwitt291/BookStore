using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class EFBookstoreRespository : IBookstoreRespository
    {
        private BookstoreContext context { get; set; }

        public EFBookstoreRespository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Books> Books => context.Books;
    }
}
