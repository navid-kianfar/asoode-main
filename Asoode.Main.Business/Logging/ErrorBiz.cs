using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Asoode.Main.Core.Contracts.Logging;
using Asoode.Main.Data.Contexts;
using Asoode.Main.Data.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Asoode.Main.Business.Logging
{
    internal class ErrorBiz : IErrorBiz
    {
        private const string Dash = "---------------------------------------------------";
        private readonly IServiceProvider _serviceProvider;

        public ErrorBiz(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public string ExtractError(Exception ex)
        {
            var builder = new StringBuilder();
            builder.Append(ex.StackTrace);
            builder.Append("\r\n");
            builder.Append("\r\n");
            builder.Append(Dash);
            if (ex.InnerException != null)
            {
                builder.Append(ex.InnerException);
                builder.Append("\r\n");
                builder.Append("\r\n");
                builder.Append(ex.StackTrace);
            }

            return builder.ToString();
        }

        public async Task LogException(Exception ex)
        {
            using (var unit = _serviceProvider.GetService<ApplicationDbContext>())
            {
                try
                {
                    await unit.ErrorLogs.AddAsync(new ErrorLog
                    {
                        Description = ex.Message,
                        ErrorBody = ExtractError(ex)
                    });
                    await unit.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.ToString());
                }
            }
        }
    }
}