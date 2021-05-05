using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Outputs.Controllers;
using Outputs.Outputs;
using Outputs.Responses;

namespace Outputs.Factories
{
    public static class HttpActionResultFactory
    {
        public static async Task<IActionResult> CreateActionResultAsync(AsloBaseController controller, BaseResponse obj, HttpStatusCode code = HttpStatusCode.OK)
        {
            if (code == HttpStatusCode.OK)
            {
                if (obj == null)
                    return await Task.FromResult(controller.Ok(new BaseResponse { ElapsedTime = controller.ElapsedWatch.Elapsed }));
                obj.ElapsedTime = controller.ElapsedWatch.Elapsed;
                if (obj.HasWarnings)
                    return await Task.FromResult(new ObjectResult(obj) { StatusCode = (int)HttpStatusCode.BadRequest });
                if (obj.HasErrors)
                    return await Task.FromResult(new ObjectResult(obj) { StatusCode = (int)HttpStatusCode.InternalServerError });
                return await Task.FromResult(controller.Ok(obj));
            }
            if (obj == null)
                return await Task.FromResult(new ObjectResult(new BaseResponse { ElapsedTime = controller.ElapsedWatch.Elapsed }) { StatusCode = (int)code });
            obj.ElapsedTime = controller.ElapsedWatch.Elapsed;
            return await Task.FromResult(new ObjectResult(obj) { StatusCode = (int)code });
        }
        
        public static async Task<IActionResult> CreateActionResultAsync(AsloBaseController controller, ValidationResult obj, HttpStatusCode code = HttpStatusCode.OK)
        {
            if (obj == null) 
                return await CreateActionResultAsync(controller, new BaseResponse() { ElapsedTime = controller.ElapsedWatch.Elapsed, Timestamp = DateTime.Now.ToUniversalTime() }, code);
            return await CreateActionResultAsync(controller, obj.ConvertToResponse(controller.ElapsedWatch.Elapsed), code);
        }
        
        public static async Task<IActionResult> CreateActionResultAsync(Exception exception)
        {
            return await Task.FromResult(new ObjectResult(exception.Message) { StatusCode = (int)HttpStatusCode.InternalServerError });
        }
    }
}