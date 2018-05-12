using Competencia.Data;
using SharedKernel.Common;
using System;
using System.Threading.Tasks;

namespace Competencia.Api
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;

		public UnitOfWork(AppDbContext context)
		{
			_context = context;
		}

		public async Task CommitAsync()
		{
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}
			
		}
	}
}
