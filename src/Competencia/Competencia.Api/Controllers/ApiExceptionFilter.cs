using Microsoft.AspNetCore.Mvc.Filters;

namespace Competencias.Api.Controllers
{
	public class ApiExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			if(context.Exception != null)
			{

			}
		}
	}
}
