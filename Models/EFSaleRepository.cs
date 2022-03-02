using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    //inherites 
    public class EFSaleRepository : ISaleRepository
    {
        private BookstoreContext context;
        public EFSaleRepository (BookstoreContext temp)
        {
            context = temp;
        }
        //Getting all the information
        public IQueryable<Sale> Sales => context.Sales.Include(x => x.Lines).ThenInclude(x => x.Book);

        //Once we have the info, what do we want to do?
        public void SaveSale(Sale sale)
        {
            context.AttachRange(sale.Lines.Select(x => x.Book));

            if (sale.SaleId == 0)
            {
                context.Sales.Add(sale);
            }

            context.SaveChanges();
        }
    }
}
