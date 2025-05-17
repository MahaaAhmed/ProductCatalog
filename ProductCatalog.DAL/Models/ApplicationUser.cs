using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog.DAL.Models
{
	public class ApplicationUser :IdentityUser
	{
		public string FName { get; set; }
		public string LName { get; set; }
		public bool IsAgree { get; set; }
	}
}
