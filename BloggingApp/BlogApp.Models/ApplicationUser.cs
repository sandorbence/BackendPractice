using System.ComponentModel.DataAnnotations;

using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogApp.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		string Name { get; set; }
	}
}
