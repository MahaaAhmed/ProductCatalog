using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.DAL.Exceptions
{
    public sealed class ProductNotFoundException(int id) : NotFoundException($"Product with id = {id} is not Found")
    {

    }
}
