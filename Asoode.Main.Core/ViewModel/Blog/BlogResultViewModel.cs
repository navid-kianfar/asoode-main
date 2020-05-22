using Asoode.Main.Core.ViewModel.General;

namespace Asoode.Main.Core.ViewModel.Blog
{
    public class BlogResultViewModel
    {
        public BlogViewModel Blog { get; set; }
        public GridResult<PostViewModel> Posts { get; set; }
    }
}