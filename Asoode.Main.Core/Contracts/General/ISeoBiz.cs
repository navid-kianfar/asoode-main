using System.Threading.Tasks;
using Asoode.Main.Core.ViewModel.General;

namespace Asoode.Main.Core.Contracts.General
{
    public interface ISeoBiz
    {
        Task<SiteMapViewModel[]> SiteMap();
    }
}