
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Product_Catalog.BLL.Interfaces;
using Product_Catalog.BLL.Repositories;
using Product_Catalog.BLL.Services.Classes;
using Product_Catalog.BLL.Services.Interfacies;
using Product_Catalog.DAL.Data;
using Product_Catalog.DAL.Models;
using Product_Catalog.PL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Builder = WebApplication.CreateBuilder(args);

            #region Configure services that allow Dependancy injection
            Builder.Services.AddControllersWithViews();

            Builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(Builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            Builder.Services.AddScoped<IProductRepository, ProductRepository>();
            Builder.Services.AddScoped<IProductService, ProductService>();
            //Builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            Builder.Services.AddScoped<ICategoryService, CategoryService>();
            Builder.Services.AddScoped<IDataSeeding, DataSeeding>();

            Builder.Services.AddScoped<IUnitOfwork, UnitOfWork>();
            Builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));

            Builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
            }).AddEntityFrameworkStores<StoreDbContext>().AddDefaultTokenProviders();
           

            Builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/SignIn";


            });
            #endregion


            var app = Builder.Build();

            using var scope = app.Services.CreateScope();
            var objectOfDataSeeding = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            objectOfDataSeeding.DataSeed();

            #region Configure HTTP Request piplines
            if (Builder.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            #endregion
            app.Run();
        }

        
    }
}
