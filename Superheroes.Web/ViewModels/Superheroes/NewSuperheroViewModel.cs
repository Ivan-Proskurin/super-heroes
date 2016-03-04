using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Superheroes.Web.ViewModels
{
    public class NewSuperheroViewModel : SuperheroFormViewModel
    {
        [Required(ErrorMessage = "Выберите файл с изображением.")]
        [Display(Name = "Картинка")]
        public HttpPostedFileBase PictureFile { get; set; }

        public NewSuperheroViewModel() : base() { }

        public NewSuperheroViewModel(Superhero model) : base(model) { }
    }
}