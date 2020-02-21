namespace Library.Graphical
{
	public interface IChangeableObject
	{
		/// <summary>
		/// Move the object to the next frame in its animation.
		/// </summary>
		void Tick();
	}
}
