using System;
using System.Linq;
using System.Threading.Tasks;
using Asoode.Main.Core.Contracts.Logging;
using Asoode.Main.Core.Contracts.Membership;
using Asoode.Main.Core.Primitives;
using Asoode.Main.Core.ViewModel.Membership;
using Asoode.Main.Data.Contexts;
using Asoode.Main.Data.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Asoode.Main.Business.Membership
{
    internal class PlanBiz : IPlanBiz
    {
        private readonly IServiceProvider _serviceProvider;

        public PlanBiz(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public async Task<OperationResult<PlanViewModel[]>> List()
        {
            try
            {
                using (var unit = _serviceProvider.GetService<ApplicationDbContext>())
                {
                    var plans = await unit.Plans
                        .Where(i => !i.DeletedAt.HasValue && i.Enabled)
                        .OrderBy(i => i.Type)
                        .AsNoTracking()
                        .ToArrayAsync();
                    var result = plans.Select(p => p.ToViewModel()).ToArray();
                    return OperationResult<PlanViewModel[]>.Success(result);
                }
            }
            catch (Exception ex)
            {
                await _serviceProvider.GetService<IErrorBiz>().LogException(ex);
                return OperationResult<PlanViewModel[]>.Failed();
            }
        }
    }
}