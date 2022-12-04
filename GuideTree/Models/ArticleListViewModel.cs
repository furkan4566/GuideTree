using Core.Utilities.Results;
using Entities.Entity;
using System;
using System.Collections.Generic;

namespace GuideTree.Models
{

    public class PageInfo
    {
        public int TotalItems { get; set; }//Kullanıcagımız kaç tane veritabanında veri var
        public int ItemsPerPage { get; set; }//sayfa başına göstermek istediğmiz article
        public int CurrentPage { get; set; }//active sayfa belirleme
        public string CurrentCategory { get; set; }//category var mı,yok mu

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);//total/item dan oluşucak olan kesirli ifadeleri tam sayıya çevirir.
        }
    }
      
    public class ArticleListViewModel
    {
        //Entities'teki article yi liste haline getirip Controller'a verir
        public IDataResult<List<Article>> Articles { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
