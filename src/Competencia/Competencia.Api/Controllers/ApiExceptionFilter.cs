using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Competencias.Api.Controllers
{
	public class ApiExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			if(context.Exception != null)
			{
				throw new Exception(context.Exception.Message, context.Exception.InnerException);
			}
		}
	}
}
