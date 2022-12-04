using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entity
{
    public class Article : IEntity
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsHome { get; set; }
        public int CategoryId { get; set; }

        //public bool Approved { get; set; }//eklenmedi
        public List<ArticleCategory> ArticleCategories { get; set; }
    }
}
