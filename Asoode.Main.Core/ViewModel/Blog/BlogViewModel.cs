using Asoode.Main.Core.Primitives.Enums;
using Asoode.Main.Core.ViewModel.General;

namespace Asoode.Main.Core.ViewModel.Blog
{
    public class BlogViewModel : BaseViewModel
    {
        public int Index { get; set; }
        
        public BlogType Type { get; set; }
        public string Culture { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}