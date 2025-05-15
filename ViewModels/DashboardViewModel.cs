using NewsWebApp.Models.Entities;

namespace NewsWebApp.ViewModels
{
    public class DashboardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DashboardViewModel(Article article)
        {
            Id = article.Id;
            Title = article.Title;
        }
    }
}
