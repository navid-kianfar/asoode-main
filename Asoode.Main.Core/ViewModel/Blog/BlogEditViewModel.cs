using System.ComponentModel.DataAnnotations;
using Asoode.Main.Core.Primitives.Enums;

namespace Asoode.Main.Core.ViewModel.Blog
{
    public class BlogEditViewModel
    {
        [Required]public BlogType Type { get; set; }
        public string Keywords { get; set; }
        [Required][MaxLength(2)]public string Culture { get; set; }
        [Required]public string Description { get; set; }
        [Required]public string Title { get; set; }
    }
}