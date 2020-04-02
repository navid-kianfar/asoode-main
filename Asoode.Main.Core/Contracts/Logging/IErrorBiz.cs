using System;
using System.Threading.Tasks;

namespace Asoode.Main.Core.Contracts.Logging
{
    public interface IErrorBiz
    {
        string ExtractError(Exception ex);

        Task LogException(Exception ex);
    }
}