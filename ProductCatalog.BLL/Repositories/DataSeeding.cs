
using Microsoft.EntityFrameworkCore;
using Product_Catalog.BLL.Interfaces;
using Product_Catalog.DAL.Data;
using Product_Catalog.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product_Catalog.BLL.Repositories
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
    {
        public void DataSeed()
        {
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Any())
                {
                    _dbContext.Database.Migrate();
                }


                if (!_dbContext.Categories.Any())
                {
                    var CategoriesData = File.ReadAllText(@"wwwroot/files/DataSeed/brands.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(CategoriesData);
                    if (categories != null && categories.Any())
                    {
                        _dbContext.Categories.AddRange(categories);

                    }
                }

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
