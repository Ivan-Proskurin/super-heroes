using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Superheroes.Domain;
using System.Web.Mvc;
using System.Web.Routing;

namespace Superheroes.Web.ViewModels
{
    public class SuperheroViewModel
    {
        public int SuperheroId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int Level { get; set; }
        public string DetailsUrl { get; set; }
        public string ImageUrl { get; set; }
        public string AddTalentUrl { get; set; }
        public string EditUrl { get; set; }
        public string DeleteUrl { get; set; }

        public List<TalentViewModel> Talents { get; set; }

        public SuperheroViewModel(Superhero model, RequestContext requestContext)
        {
            this.SuperheroId = model.SuperheroId;
            this.Name = model.Name;
            this.Details = model.Details;
            this.Level = model.HeroLevel;

            UrlHelper url = new UrlHelper(requestContext);
            this.ImageUrl = url.Action("Show", "Image", new { id = model.Image_FileId ?? 0 });
            this.DetailsUrl = url.Action("Details", "Superheroes", new { id = model.SuperheroId });
            this.AddTalentUrl = url.Action("New", "Talents", new { id = model.SuperheroId });
            this.EditUrl = url.Action("Edit", "Superheroes", new { id = model.SuperheroId });
            this.DeleteUrl = url.Action("Delete", "Superheroes", new { id = model.SuperheroId });
            this.Talents = new List<TalentViewModel>();
        }
    }
}