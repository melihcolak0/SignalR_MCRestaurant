namespace _81MY_SignalROrderManUI.DTOs.RecipeDtos
{
    public class RecipeListResponse
    {
        public List<ResultRecipeDto> results { get; set; }
    }

    public class ResultRecipeDto
    {
        public string name { get; set; }

        public string original_video_url { get; set; }

        public int total_time_minutes { get; set; }

        public string thumbnail_url { get; set; }
    }
}
