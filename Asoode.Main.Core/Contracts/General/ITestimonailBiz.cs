using System.Threading.Tasks;
using Asoode.Main.Core.Primitives;
using Asoode.Main.Core.ViewModel.General;

namespace Asoode.Main.Core.Contracts.General
{
    public interface ITestimonailBiz
    {
        Task<OperationResult<TestimonialViewModel[]>> Top5(string culture);
    }
}