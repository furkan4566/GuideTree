using Entities.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GuideTree.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        [Display(Name = "Kategori ismi", Prompt = "Kategori İsmi Giriniz")]
        [Required(ErrorMessage = "Kategori ismi zorunlu alandır.")]//title zorunlu alan yapar olmaz ise errormasage verir
        [StringLength(15, MinimumLength = 3, ErrorMessage = "En az 3 karakter,En çok 15 karakter")]
        public string Name { get; set; }
        [StringLength(15, MinimumLength = 3, ErrorMessage = "En az 3 karakter,En çok 15 karakter")]
        [Required(ErrorMessage = "Url kısmı zorunlu alandır.")]
        public string Url { get; set; }
        public List<Article> Articles { get; set; }
    }
}
