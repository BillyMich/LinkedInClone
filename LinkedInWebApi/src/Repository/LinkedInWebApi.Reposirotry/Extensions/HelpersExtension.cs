namespace LinkedInWebApi.Reposirotry.Extensions
{
    /// <summary>
    /// Provides extension methods for the Helpers class.
    /// </summary>
    public static class HelpersExtension
    {
        /// <summary>
        /// Checks if there are any common elements between two lists.
        /// </summary>
        /// <typeparam name="T">The type of elements in the lists.</typeparam>
        /// <param name="list1">The first list.</param>
        /// <param name="list2">The second list.</param>
        /// <returns>True if there are common elements, otherwise false.</returns>
        public static bool HaveCommonElements<T>(this List<T> list1, List<T> list2)
        {
            // Check if there are any common elements between the two lists
            return list1.Intersect(list2).Any();
        }
    }
}
