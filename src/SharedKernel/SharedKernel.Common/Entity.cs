using System;

namespace SharedKernel.Common
{
	public abstract class Entity<TId> : IEquatable<Entity<TId>>
	{
		private TId _id;

		protected Entity(TId id)
		{
			if (Equals(id, default(TId)))
			{
				throw new ArgumentException("The ID cannot be the default value.", "id");
			}

			_id = id;
		}

		protected Entity()
		{

		}

		public TId Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public override bool Equals(object obj)
		{
			var entity = obj as Entity<TId>;
			if (entity != null)
			{
				return Equals(entity);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public bool Equals(Entity<TId> other)
		{
			if (other == null)
			{
				return false;
			}
			return Id.Equals(other.Id);
		}
	}
}