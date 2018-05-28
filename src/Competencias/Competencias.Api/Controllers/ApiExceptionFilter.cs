using Microsoft.AspNetCore.Mvc.Filters;
using SharedKernel.Common;

namespace Competencias.Api.Controllers
{
	public class ApiExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			if(context.Exception is ApplicationException)
			{
				//TODO
			}

			if(context.Exception != null)
			{
				throw new System.Exception(context.Exception.Message, context.Exception.InnerException);
			}
		}
	}
}
