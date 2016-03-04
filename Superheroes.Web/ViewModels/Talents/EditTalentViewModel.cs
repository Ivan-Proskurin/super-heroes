using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Superheroes.Web.ViewModels
{
    public class EditTalentViewModel : TalentFormViewModel
    {
        [Display(Name = "Картинка")]
        public HttpPostedFileBase PictureFile { get; set; }

        public EditTalentViewModel() : base() { }

        public EditTalentViewModel(SuperheroTalent model) : base(model)
        {
        }
    }
}