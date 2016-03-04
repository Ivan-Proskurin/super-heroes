using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Superheroes.Web.ViewModels
{
    public class TalentViewModel
    {
        public string HeroName { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public string EditUrl { get; set; }
        public string DeleteUrl { get; set; }
        public string DetailsUrl { get; set; }
        public string BackToHeroUrl { get; set; }

        public TalentViewModel(SuperheroTalent talent, RequestContext requestContext)
        {
            UrlHelper url = new UrlHelper(requestContext);
            if (talent.Superhero != null)
            {
                this.HeroName = talent.Superhero.Name;
            }
            this.Name = talent.Name;
            this.Details = talent.Details;
            this.ImageUrl = url.Action("Show", "Image", new { id = talent.Image_FileId ?? 0 });
            this.EditUrl = url.Action("Edit", "Talents", new { id = talent.TalentId });
            this.DeleteUrl = url.Action("Delete", "Talents", new { id = talent.TalentId });
            this.DetailsUrl = url.Action("Details", "Talents", new { id = talent.TalentId });
            this.BackToHeroUrl = url.Action("Details", "Superheroes", new { id = talent.OwnerId });
        }
    }
}