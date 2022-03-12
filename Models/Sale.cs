using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Sale
    {
        [Key]
        [BindNever]
        public int SaleId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }
        [Required(ErrorMessage = "Please enter a name:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter an email:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter an address line:")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "Please enter a city:")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state:")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a zipcode:")]
        public string Zipcode { get; set; }

//not passed through URL
        [BindNever]
        public bool PaymentReceived { get; set; }
    }
}
