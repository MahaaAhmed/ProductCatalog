
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Product_Catalog.PL.ViewModels
{
	public class SignUpViewModel
	{ 
		[Required(ErrorMessage ="First Name Is Required")]
        public string FName { get; set; }
		[Required(ErrorMessage = "Last Name Is Required")]
		public string LName { get; set; }
		
		[Required(ErrorMessage = "Required To Agree")]
		public bool IsAgree { get; set; }
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage ="InValid Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Password Is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required(ErrorMessage = "Confirm Password Is Required")]
		[Compare(nameof(Password),ErrorMessage ="Confirm Password doesn't match Password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}
