﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using NewsWebApp.Models.Entities;

namespace NewsWebApp.ViewModels
{
    public class HomeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsPriority { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; } 
        public string? ImageLink { get; set; }
        public string? ImageDescription { get; set; }
        public string TimeSinceCreation { get; set; }

        public HomeViewModel (Article article)
        {
            Id = article.Id;
            Title = article.Title;
            IsPriority = article.IsPriority;
            Author = article.Author;
            Category = article.Category;
            Description = article.Description;
            CreatedDate = article.CreatedDate;
            ImageLink = article.ImageLink;
            ImageDescription = article.ImageDescription;
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
