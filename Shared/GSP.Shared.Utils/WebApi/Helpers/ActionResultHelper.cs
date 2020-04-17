using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GSP.Shared.Utils.WebApi.Helpers
{
    public static class ActionResultHelper
    {
        public static IActionResult JsonResult<T>(T model, HttpStatusCode code)
        {
            JsonResult jsonResult = new JsonResult(model)
            {
                StatusCode = (int)code
            };

            return jsonResult;
        }

        public static IActionResult CreatedAt<T>(T model)
        {
            return JsonResult(model, HttpStatusCode.Created);
        }
    }
}