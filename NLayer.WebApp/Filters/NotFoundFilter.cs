using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.Entity;
using NLayer.Core.Services;
using NLayer.WebApp.Models;

namespace NLayer.WebApp.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }
            else
            {
                var id = (int)idValue;
                var entity = await _service.AnyAsync(x => x.Id == id);
                if (entity)
                {
                    await next.Invoke();
                    return;
                }
                else
                {
                    var errorViewModel = new ErrorViewModel();
                    errorViewModel.Errors.Add($"{typeof(T).Name}- {id} not found");

                    context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);
                }
            }
        }
    }
}
