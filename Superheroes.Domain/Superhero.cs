using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.Domain
{
    public class Superhero
    {
        [Key]
        [Display(Name = "Код героя")]
        public int SuperheroId { get; set; }

        [Required]
        [Display(Name = "Имя героя")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Имя героя должно быть от 2 до 30 символов")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Details { get; set; }

        [ForeignKey("Image_FileId")]
        [Display(Name = "Картинка")]
        public DbFile Image { get; set; }

        [ForeignKey("Image")]
        [Display(Name = "Код картинки")]
        public int? Image_FileId { get; set; }

        [Display(Name = "Уровень героя")]
        [Range(1, 80, ErrorMessage = "Уровень героя дожен быть от 1 до 80")]
        public int HeroLevel { get; set; }

    }
}
