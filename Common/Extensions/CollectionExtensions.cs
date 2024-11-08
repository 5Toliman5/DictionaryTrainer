namespace Common.Extensions
{
	public static class CollectionExtensions
	{
		public static bool IsNullOrEmpty<T>(this ICollection<T>? collection)
		{
			return collection is null || collection.Count == 0;
		}

		public static bool IsNullOrEmpty<T>(this IEnumerable<T>? collection)
		{
			return collection is null || !collection.Any();
		}
	}
}
