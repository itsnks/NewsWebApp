using NewsWebApp.Models.Entities;

namespace NewsWebApp.ViewModels
{
    public class DashboardViewModel
    {
        public IQueryable<Article> Articles { get; set; }

        public  string IdSortOrder { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public string Term { get; set; }
        public string OrderBy { get; set; }
        /*        public int Id { get; set; }
                public string Title { get; set; }
                public DashboardViewModel(Article article)
                {
                    Id = article.Id;
                    Title = article.Title;
                }*/
    }
}
