using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Product_Catalog.DAL.Models;
using Product_Catalog.PL.Helpers;
using Product_Catalog.PL.ViewModels;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Email = Product_Catalog.PL.Helpers.Email;

namespace Demo.PL.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			
		}


        [Authorize]
        public IActionResult ShowClaims()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            return Json(claims);
        }



	  

        #region SignUp
        [HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel model)
		{
			if (ModelState.IsValid) 
			{
				var user = new ApplicationUser()
				{
					UserName = model.Email.Split("@")[0], 
					Email = model.Email,
					IsAgree = model.IsAgree,
					FName = model.FName,
					LName = model.LName,


				};
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					return RedirectToAction(nameof(SignIn));
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}


			}
			return View(model);
		}
		#endregion

		#region Login
		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user is not null)
				{
					var flag = await _userManager.CheckPasswordAsync(user, model.Password);
					if (flag)
					{
						var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
						if (result.Succeeded)
						{
                            var roles = await _userManager.GetRolesAsync(user);

                            if (roles.Contains("Admin"))
                            {
                                // Redirect admin to All Products
                                return RedirectToAction(nameof(ProductController.AdminIndex), "Product");
                            }
                            else
                            {
                                // Redirect normal user to Durated Products
                                return RedirectToAction(nameof(ProductController.Index), "Product");
                            }
                        }
							return RedirectToAction(nameof(ProductController.Index), "Product");
					}
				}
				ModelState.AddModelError(string.Empty, "Invalid Login");
			}
			return View(model);
		}
		#endregion

		#region Sign out

		public async Task<IActionResult> SignOut()
		{
		    await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(SignIn));

		}
		#endregion

		#region Forget Password

		public IActionResult ForgetPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
		{
			if(ModelState.IsValid)
			{
				var user =await  _userManager.FindByEmailAsync(model.Email);
				if(user is not null)
				{
					var token =await _userManager.GeneratePasswordResetTokenAsync(user);
					var ResetPasswordURL = Url.Action("ResetPassword", "Account", new { email = model.Email ,token = token  });

					var email = new Email()
					{
						Subject = "Reset Your Password",
						To = model.Email,
						Body = ResetPasswordURL
					};	
					EmailSettings.SendEmail(email);
					return RedirectToAction(nameof(CheckYourInbox));




				}
				ModelState.AddModelError(string.Empty, "Invalid Email");
			}
			return View(model);
		}

		public IActionResult CheckYourInbox()
		{
			return View();
		}



		public IActionResult ResetPassword(string email , string token)
		{
			TempData["email"] = email;
			TempData["token"] = token;

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if(ModelState.IsValid)
			{
				string email = TempData["email"] as string;
				string token = TempData["token"] as string;
				var user =await _userManager.FindByEmailAsync(email);

				var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
				if (result.Succeeded)
				{
					return RedirectToAction(nameof(SignIn));
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View(model);
		}


		#endregion




	}
}
