using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Product_Catalog.BLL.Dtos;
using Product_Catalog.BLL.Interfaces;
using Product_Catalog.BLL.Repositories;
using Product_Catalog.BLL.Services.Classes;
using Product_Catalog.BLL.Services.Interfacies;
using Product_Catalog.DAL.Exceptions;
using Product_Catalog.DAL.Models;
using Product_Catalog.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{

	public class ProductController(IProductService _productService, IMapper _mapper, IUnitOfwork _unitOfwork,IWebHostEnvironment _environment, ILogger<ProductController> _logger) : Controller
    {
        #region Index

        public async Task<IActionResult> Index([FromQuery] ProductQueryParameters queryParameters)
        {

            dynamic Products = null!;
            dynamic returnedProducts = null!;
            if (string.IsNullOrEmpty(queryParameters.Search))
            {
                Products = await _productService.GetAllProductsAsync(queryParameters);
                returnedProducts = _mapper.Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(Products);
            }
            else
            {
                Products = _productService.SearchProductByName(queryParameters.Search);
                returnedProducts = _mapper.Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(Products);


            }

            return View(returnedProducts);
        }

        public async Task<IActionResult> AdminIndex()
        {
            dynamic Products = null!;
            dynamic returnedProducts = null!;
            Products = await _productService.GetAllProductsAsyncForAdmin();
            returnedProducts = _mapper.Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(Products);
            return View(returnedProducts);
        } 
        #endregion

        #region Create Product

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductViewModel productVM)
        {
            if (ModelState.IsValid) // server side validation
            {
                try
                {
                    var productCreatedDto = new ProductDto()
                    {
                        Name = productVM.Name,
                        CategoryId = productVM.CategoryId,
                        CreatedByUserId = productVM.CreatedByUserId,
                        CreationDate = productVM.CreationDate,
                        Duration = productVM.Duration,
                        LastModifiedOn = productVM.LastModifiedOn,
                        Price = productVM.Price,
                        StartDate = productVM.StartDate,


                    };
          
                    int result = _productService.CreateProduct(productCreatedDto); 
                 
                    if (result > 0)
                    {
                        TempData["Message"] = "Product Created Succesfully! ";
                        return RedirectToAction(nameof(Index));

                    }



                    else
                    {
                        TempData["Message"] = "Product Creation failed ";

                        ModelState.AddModelError(string.Empty, "Product can't be created !!");
                        return RedirectToAction(nameof(Index));

                    }

                }
                catch (Exception ex)
                {
                    // log exception 
                    if (_environment.IsDevelopment())
                    {
                        
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                       
                        _logger.LogError(ex.Message);
                    }



                }
            }
            return View(productVM);
        }




        #endregion
        #region Details
        public async Task<IActionResult> Details(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var Product = await _productService.GetProductByIdAsync(id.Value);
            var mappedProduct = _mapper.Map<ProductDto, ProductViewModel>(Product);

            if (Product is null)
                return NotFound(new ProductNotFoundException(id.Value));
            return View(ViewName, mappedProduct);
        }
        public async Task<IActionResult> AdminDetails(int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var Product = await _productService.GetProductByIdAsyncForAdmin(id.Value);
            var mappedProduct = _mapper.Map<ProductDto, ProductViewModel>(Product);

            if (Product is null)
                return NotFound(new ProductNotFoundException(id.Value));
            return View(ViewName, mappedProduct);
        }
        #endregion       
        #region Edit Product
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit([FromRoute] int id, ProductViewModel Product)
        {
            if (id != Product.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {

                    var mappedProduct = _mapper.Map<ProductViewModel, ProductDto>(Product);
                    _productService.UpdateProduct(mappedProduct);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(Product);

        }
        #endregion

        #region Delete Product
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                var deleted = _productService.DeleteProduct(id);
                if (deleted)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Product Is Not Deleted!");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message);
                }

            }
            return RedirectToAction(nameof(Index));

        } 
        #endregion



    }
}
