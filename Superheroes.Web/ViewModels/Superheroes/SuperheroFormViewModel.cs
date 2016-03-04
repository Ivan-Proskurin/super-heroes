using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Superheroes.Web.ViewModels
{
    public class SuperheroFormViewModel
    {
        [Required]
        [Display(Name = "Имя героя")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Имя героя должно быть от 2 до 30 символов")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Details { get; set; }

        [Display(Name = "Уровень героя")]
        [Range(1, 80, ErrorMessage = "Уровень героя дожен быть от 1 до 80")]
        public int HeroLevel { get; set; }

        public SuperheroFormViewModel()
        {

        }

        public SuperheroFormViewModel(Superhero model)
        {
            this.Name = model.Name;
            this.Details = model.Details;
            this.HeroLevel = model.HeroLevel;
        }
    }
}