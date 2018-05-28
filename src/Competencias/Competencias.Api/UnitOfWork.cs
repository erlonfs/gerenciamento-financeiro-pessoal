using Competencias.Domain;
using SharedKernel.Common;
using System;
using System.Threading.Tasks;

namespace Competencias.Api
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
				using (var transaction = await _context.Database.BeginTransactionAsync())
				{
					try
					{
						await _context.SaveChangesAsync();

						transaction.Commit();

					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
