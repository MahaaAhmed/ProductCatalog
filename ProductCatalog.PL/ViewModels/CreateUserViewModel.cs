using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Product_Catalog.PL.ViewModels
{
    public class CreateUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
        public IEnumerable<string> Roles { get; set; }
        

        public List<SelectListItem> AvailableRoles { get; set; } // For dropdown
    }
}
