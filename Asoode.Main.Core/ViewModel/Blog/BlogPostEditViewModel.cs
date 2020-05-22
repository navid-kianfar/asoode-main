using System.ComponentModel.DataAnnotations;

namespace Asoode.Main.Core.ViewModel.Blog
{
    public class BlogPostEditViewModel
    {
        public string Keywords { get; set; }
        [Required]public string Description { get; set; }
        [Required]public string Title { get; set; }
        public string Summary { get; set; }
        [Required]public string Text { get; set; }
    }
}