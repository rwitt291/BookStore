using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class SaleController : Controller
    {
        private ISaleRepository repo { get; set; }
        private Basket basket { get; set; }
        //set up a constructor
        public SaleController (ISaleRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Sale());
        }

        [HttpPost]
        public IActionResult Checkout(Sale sale)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                sale.Lines = basket.Items.ToArray();
                repo.SaveSale(sale);
                basket.ClearCart();

                return RedirectToPage("/Completion");
            }
            else
            {
                return View();
            }
        }
    }
}
