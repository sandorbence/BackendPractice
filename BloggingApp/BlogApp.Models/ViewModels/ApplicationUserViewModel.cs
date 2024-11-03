using BlogApp.Models.Models;

namespace BlogApp.Models.ViewModels
{
    public class ApplicationUserViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}
