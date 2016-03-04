using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.Domain
{
    public class SuperheroTalent
    {
        [Key]
        [Display(Name = "Код способности")]
        public int TalentId { get; set; }

        [Required]
        [Display(Name = "Код героя")]
        [ForeignKey("Superhero")]
        public int OwnerId { get; set; }

        [Required]
        [Display(Name = "Герой")]
        [ForeignKey("OwnerId")]
        public Superhero Superhero { get; set; }

        [Required]
        [Display(Name = "Название")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Название способности должно быть от 2 до 30 символов")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Details { get; set; }

        [Display(Name = "Картинка")]
        [ForeignKey("Image_FileId")]
        public DbFile Image { get; set; }

        [Display(Name = "Код картинки")]
        [ForeignKey("Image")]
        public int? Image_FileId { get; set; }
    }
}
