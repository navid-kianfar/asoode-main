using System.Threading.Tasks;
using Asoode.Main.Core.Primitives;
using Asoode.Main.Core.ViewModel.Membership;

namespace Asoode.Main.Core.Contracts.Membership
{
    public interface IPlanBiz
    {
        Task<OperationResult<PlanViewModel[]>> List();
    }
}