using Entities.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuideTree.Models
{
    public class ArticleModel
    {
        //JQUERY Validation işlemlerini dinamik hale getirir sadece kütüphane eklemek yeterlidir.
        //HTTPPOST yenileme yaparsa HTTPGET den gelen verileri tekrar alması gerekir,
        //Kullanılması için cshtml sayfasında çalıştırmak lazım
        //[Range(6,1000,ErrorMessage ="FİYAT 6 İLE 1000 ARASI OLMALI")]
        //Create Model Sayfasını responsive tasarım için kullanılır
        public int ArticleId { get; set; }

        //[Display(Name="Makele ismi",Prompt ="Makale İsmi Giriniz")]
        //[Required(ErrorMessage ="Başlık kısmı zorunlu alandır.")]//title zorunlu alan yapar olmaz ise errormasage verir
        //[StringLength(60,MinimumLength=5,ErrorMessage ="En az 5 karakter,En çok 60 karakter")]
        public string Title { get; set; }
        [StringLength(15, MinimumLength = 2, ErrorMessage = "En az 2 karakter,En çok 15 karakter")]
        [Required(ErrorMessage = "Url kısmı zorunlu alandır.")]
        public string Url { get; set; }
        [StringLength(int.MaxValue, MinimumLength =5, ErrorMessage = "En az 5 karakter ")]
        [Required(ErrorMessage = "Description kısmı zorunlu alandır.")]//double veya decimal ise nullumble(double?) şeklinde olmalı yoksa çalışmaz
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Ana sayfa'da olsun mu?")]
        public bool IsHome { get; set; }
        //Category
        public List<Category> SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }
    }
}
