using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Superheroes.Web.ViewModels
{
    public class EditSuperheroViewModel : SuperheroFormViewModel
    {
        [Display(Name = "Картинка")]
        public HttpPostedFileBase PictureFile { get; set; }

        public EditSuperheroViewModel() : base()
        {

        }

        public EditSuperheroViewModel(Superhero model) : base(model) { }
    }
}