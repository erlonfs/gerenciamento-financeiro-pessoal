namespace SharedKernel.Common
{
	public interface IHandler<T> where T : IDomainEvent
	{
		void Handle(T e);
	}
}
