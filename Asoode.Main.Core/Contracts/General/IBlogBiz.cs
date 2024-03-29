using System;
using System.Collections;
using System.Threading.Tasks;
using Asoode.Main.Core.Primitives;
using Asoode.Main.Core.ViewModel.Blog;
using Asoode.Main.Core.ViewModel.General;

namespace Asoode.Main.Core.Contracts.General
{
    public interface IBlogBiz
    {
        Task<OperationResult<BlogViewModel>> Blog(string culture);
        Task<OperationResult<GridResult<PostViewModel>>> Posts(Guid blogId, GridFilter model);
        Task<OperationResult<PostViewModel>> Post(string blogId);
        Task<OperationResult<BlogViewModel>> Faq(string culture);
        Task<OperationResult<PostViewModel[]>> AllPosts(string culture);
        Task<OperationResult<BlogViewModel[]>> AllBlogs(string culture);
    }
}