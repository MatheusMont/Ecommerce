using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Validation
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = CustomResponse(context.ModelState);
            }
        }

        public static IActionResult ControllerBadRequestResponse(ModelStateDictionary modelState)
        {
            return CustomResponse(modelState);
        }

        private static BadRequestObjectResult CustomResponse(ModelStateDictionary modelState)
        {
            var errorsInModelState = modelState
                                        .Where(x => x.Value.Errors.Count > 0)
                                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage)).ToArray();

            var errors = new List<dynamic>();

            foreach (var error in errorsInModelState)
            {
                foreach (var subError in error.Value)
                {
                    var errorModel = new
                    {
                        FieldName = error.Key,
                        Message = subError
                    };

                    errors.Add(errorModel);
                }
            }

            var responseObj = new
            {
                Message = "Bad Request",
                Errors = errors
            };

            return new BadRequestObjectResult(responseObj);
        }
    }
}
