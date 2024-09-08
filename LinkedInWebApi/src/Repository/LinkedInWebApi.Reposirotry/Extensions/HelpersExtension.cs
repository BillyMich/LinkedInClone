namespace LinkedInWebApi.Reposirotry.Extensions
{
    public static class HelpersExtension
    {
        public static bool HaveCommonElements<T>(this List<T> list1, List<T> list2)
        {
            // Check if there are any common elements between the two lists
            return list1.Intersect(list2).Any();
        }
    }
}
