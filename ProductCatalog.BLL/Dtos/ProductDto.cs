using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
