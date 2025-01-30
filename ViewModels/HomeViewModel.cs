using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NewsWebApp.ViewModels
{
    public class HomeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPriority { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ImageLink { get; set; }
        public string TimeSinceCreation { 
            get 
            { 
                TimeSpan TimeElapsed = DateTime.Now - CreatedDate;
                if (TimeElapsed.TotalSeconds < 60)
                {
                    return $"{(int)TimeElapsed.TotalSeconds} seconds ago";
                }
                if (TimeElapsed.TotalMinutes < 60)
                {
                    return $"{(int)TimeElapsed.TotalMinutes} minutes ago";
                }
                if (TimeElapsed.TotalHours < 24)
                {
                    return $"{(int)TimeElapsed.TotalHours} hours ago";
                }
                if (TimeElapsed.TotalDays < 365)
                {
                    return $"{(int)TimeElapsed.TotalDays} days ago";
                }

                return CreatedDate.ToString("MMMM dd, YYYY");
            }
        }
    }
}
