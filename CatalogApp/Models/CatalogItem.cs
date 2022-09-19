using System.ComponentModel.DataAnnotations;

namespace CatalogApp.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле Назва товару не може бути пустим")]
        [MinLength(3, ErrorMessage ="Мінімум 3 символи")]
        [Display(Name = "Назва товару")]
        public string Name { get; set; }
        [Display(Name = "Ціна")]
        public double Price { get; set; }
        [Display(Name = "Кількість")]
        public double Quantity { get; set; }
        [Display(Name = "Фото")]
        public string ImgPath { get; set; }
    }
}
