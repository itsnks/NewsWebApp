using NewsWebApp.Models.Entities;

namespace NewsWebApp.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? ImageLink { get; set; }
        public string TimeSinceCreation { get; set; }

        public ArticleViewModel(Article article)
        {
            Id = article.Id;
            Title = article.Title;
            Content = article.Content;
            Author = article.Author;
            Description = article.Description;
            CreatedDate = article.CreatedDate;
            ImageLink = article.ImageLink;
            TimeSpan TimeElapsed = DateTime.UtcNow - article.CreatedDate;
            if (TimeElapsed.TotalMinutes < 60)
                TimeSinceCreation = $"{Math.Floor(TimeElapsed.TotalMinutes)} minutes ago";
            else if (TimeElapsed.TotalHours < 24)
                TimeSinceCreation = $"{Math.Floor(TimeElapsed.TotalHours)} hours ago";
            else if (TimeElapsed.TotalHours >= 24)
                TimeSinceCreation = $"{Math.Floor(TimeElapsed.TotalDays)} days ago";
            else
                TimeSinceCreation = article.CreatedDate.ToString("yyyy MMMM dd");

        }
    }
}
