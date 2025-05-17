using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Specifications
{
    public class CategorySpecifications :BaseSpecifications<Category, int>
    {
        public CategorySpecifications():base(null)
        {
            
        }
    }
}
