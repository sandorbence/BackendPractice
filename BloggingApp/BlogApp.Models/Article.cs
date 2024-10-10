using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models
{
	public class Article
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(30)]
		public string Title { get; set; }
		[Required]
		[MaxLength(2000)]
		public string Text { get; set; }
		[Required]
		public int ApplicationUserId { get; set; }
		[ForeignKey(nameof(ApplicationUserId))]
		ApplicationUser ApplicationUser { get; set; }
	}
}
