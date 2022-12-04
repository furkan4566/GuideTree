using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ArticleDetailDto:IDto
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleImageUrl { get; set; }
        public string ArticleDescription { get; set; }

        public string CategoryName { get; set; }
        public string CategoryUrl { get; set; }
    }
}
