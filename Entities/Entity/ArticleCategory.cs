using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entity
{
    public class ArticleCategory : IEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
