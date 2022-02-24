using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Basket
    {

        //declaring and initializing
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        // adding an item
        public void AddItem (Books book, int qty)
        {
            BasketLineItem line = Items.Where(b => b.Book.BookId == book.BookId)
            .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty,
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Book.Price * x.Quantity);

            return sum;
        }
    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }

    }
}
