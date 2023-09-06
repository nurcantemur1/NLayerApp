﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Services;

namespace NLayer.API.Filters
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
                    context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Error(404, $"{typeof(T).Name}-{id} not found"));
                }
            }
        }
    }
}
