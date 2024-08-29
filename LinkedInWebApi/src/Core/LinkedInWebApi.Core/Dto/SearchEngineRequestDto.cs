namespace LinkedInWebApi.Core.Dto
{
    public class SearchEngineRequestDto
    {

        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }

        public List<int>? Ids { get; set; }

        public string? SearchText { get; set; }

    }
}
