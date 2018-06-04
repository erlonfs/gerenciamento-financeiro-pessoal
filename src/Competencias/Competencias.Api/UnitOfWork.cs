using Competencias.Domain;
using SharedKernel.Common;
using System;
using System.Threading.Tasks;

namespace Competencias.Api
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _appContext;

		public UnitOfWork(AppDbContext appContext)
		{
			_appContext = appContext;
		}

		public async Task CommitAsync()
		{
			try
			{
				using (var transaction = await _appContext.Database.BeginTransactionAsync())
				{
					try
					{
						await _appContext.SaveChangesAsync();

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
