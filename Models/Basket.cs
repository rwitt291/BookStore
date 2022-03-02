using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Basket
    {

        //declaring and initializing
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        // adding an item
        public virtual void AddItem (Books book, int qty)
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

        public virtual void RemoveItem (Books book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Book.Price * x.Quantity);

            return sum;
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }
    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Books Book { get; set; }
        public int Quantity { get; set; }

    }
}
