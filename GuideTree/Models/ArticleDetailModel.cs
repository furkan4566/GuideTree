using Core.Utilities.Results;
using Entities;
using Entities.DTOs;
using System.Collections.Generic;

namespace GuideTree.Models
{
    public class ArticleDetailModel
    {
        public IDataResult<ArticleDetailDto> ArticleDetail { get; set; }    
        public IDataResult<List<ArticleDetailDto>> ArticleDetails { get; set; }
    }
}
