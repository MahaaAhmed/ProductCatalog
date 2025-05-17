
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Http;

namespace Product_Catalog.PL.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        //public string CategoryName { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

    }
}
