using NewsWebApp.Models.Entities;

namespace NewsWebApp.ViewModels
{
    public class DashboardViewModel
    {
        public IQueryable<Article> Articles { get; set; }


        /*        public int Id { get; set; }
                public string Title { get; set; }
                public DashboardViewModel(Article article)
                {
                    Id = article.Id;
                    Title = article.Title;
                }*/
    }
}
