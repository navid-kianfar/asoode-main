using System;
using System.Linq;
using System.Threading.Tasks;
using Asoode.Main.Business.Extensions;
using Asoode.Main.Core.Contracts.General;
using Asoode.Main.Core.Contracts.Logging;
using Asoode.Main.Core.Primitives;
using Asoode.Main.Core.Primitives.Enums;
using Asoode.Main.Core.ViewModel.Blog;
using Asoode.Main.Core.ViewModel.General;
using Asoode.Main.Data.Contexts;
using Asoode.Main.Data.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Asoode.Main.Business.General
{
    internal class BlogBiz : IBlogBiz
    {
        private readonly IServiceProvider _serviceProvider;

        public BlogBiz(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public async Task<OperationResult<BlogViewModel>> Blog(string culture)
        {
            try
            {
                using (var unit = _serviceProvider.GetService<ApplicationDbContext>())
                {
                    var blog = await unit.Blogs.AsNoTracking()
                        .SingleOrDefaultAsync(i => i.Culture == culture && i.Type == BlogType.Post);
                    
                    return OperationResult<BlogViewModel>.Success(blog.ToViewModel());
                }
            }
            catch (Exception ex)
            {
                await _serviceProvider.GetService<IErrorBiz>().LogException(ex);
                return OperationResult<BlogViewModel>.Failed();
            }
        }

        public async Task<OperationResult<GridResult<PostViewModel>>> Posts(Guid blogId, GridFilter model)
        {
            try
            {
                using (var unit = _serviceProvider.GetService<ApplicationDbContext>())
                {
                    var query = unit.BlogPosts
                        .Where(i => i.BlogId == blogId)
                        .OrderBy(i => i.CreatedAt);
                    return await DbHelper.GetPaginatedData(query, tuple =>
                    {
                        var (items, startIndex) = tuple;
                        return items.Select((i, index) =>
                        {
                            var vm = i.ToViewModel();
                            vm.Index = startIndex + index + 1;
                            return vm;
                        }).ToArray();
                    }, model.Page, model.PageSize);
                }
            }
            catch (Exception ex)
            {
                await _serviceProvider.GetService<IErrorBiz>().LogException(ex);
                return OperationResult<GridResult<PostViewModel>>.Failed();
            }
        }

        public async Task<OperationResult<PostViewModel>> Post(string postKey)
        {
            try
            {
                using (var unit = _serviceProvider.GetService<ApplicationDbContext>())
                {
                    var post = await unit.BlogPosts
                        .AsNoTracking()
                        .SingleOrDefaultAsync(i => i.Key == postKey);
                    if (post == null) return OperationResult<PostViewModel>.NotFound();
                    return OperationResult<PostViewModel>.Success(post.ToViewModel());
                }
            }
            catch (Exception ex)
            {
                await _serviceProvider.GetService<IErrorBiz>().LogException(ex);
                return OperationResult<PostViewModel>.Failed();
            }
        }
    }
}