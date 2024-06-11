namespace LinkedInWebApi.Core.Dto
{
    public class SearchEngineResponseDto<Model>
    {

        public List<Model> ListOfModels;

        public int TotalCount;

        public int PageNumber;

        public int PageSize;

    }
}
