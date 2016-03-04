using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Superheroes.Web.ViewModels
{
    public class TalentFormViewModel
    {
        [Required]
        [Display(Name = "Название")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Название способности должно быть от 2 до 30 символов")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Details { get; set; }

        public TalentFormViewModel() { }

        public TalentFormViewModel(SuperheroTalent model)
        {
            this.Name = model.Name;
            this.Details = model.Details;
        }
    }
}