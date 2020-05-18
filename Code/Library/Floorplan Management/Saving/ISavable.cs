using System;

namespace Library
{
	public interface ISavable
	{
		Guid Id { get; }
		bool IsDeletable { get; }

		void DeleteAllChildren();
	}
}
