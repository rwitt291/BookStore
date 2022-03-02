using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    //template to build the rest
    public interface ISaleRepository
    {
        IQueryable<Sale> Sales { get; }

        public void SaveSale(Sale sale);
    }
}
