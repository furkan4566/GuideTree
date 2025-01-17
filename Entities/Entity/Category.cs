﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entity
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public List<ArticleCategory> ArticleCategories { get; set; }
    }
}
