using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Superheroes.Web.ViewModels
{
    public class NewTalentViewModel : TalentFormViewModel
    {
        public int SuperheroId { get; set; }

        [Required(ErrorMessage = "Выберите файл с изображением")]
        [Display(Name = "Картинка")]
        public HttpPostedFileBase PictureFile { get; set; }

        public NewTalentViewModel() : base() { }

        public NewTalentViewModel(SuperheroTalent model) : base(model)
        {
            this.SuperheroId = model.OwnerId;
        }
    }
}