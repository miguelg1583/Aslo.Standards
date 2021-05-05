using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Aslo.Standards.Outputs.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Aslo.Standards.Outputs.Controllers
{
    public class AsloBaseController : ControllerBase
    {
        private readonly ILogger _logger;
        public readonly Stopwatch ElapsedWatch = new Stopwatch();

        public AsloBaseController(ILogger logger)
        {
            _logger = logger;
        }

        protected async Task<IActionResult> ExecuteWithExceptionHandlingAsync(Func<Task<IActionResult>> func)
        {
            ElapsedWatch.Start();
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Exception: {Ex}", ex);
                return await HttpActionResultFactory.CreateActionResultAsync(ex);
            }

            finally
            {
                ElapsedWatch.Stop();
            }
        }
    }
}