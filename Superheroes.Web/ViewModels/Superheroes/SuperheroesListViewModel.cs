using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Superheroes.Domain;
using System.Web.Routing;

namespace Superheroes.Web.ViewModels
{
    public class SuperheroesListViewModel
    {
        public List<SuperheroViewModel> Superheroes { get; set; }

        public SuperheroesListViewModel(List<Superhero> superheroes, RequestContext requestContext)
        {
            this.Superheroes = new List<SuperheroViewModel>();
            foreach (Superhero hero in superheroes)
            {
                this.Superheroes.Add(new SuperheroViewModel(hero, requestContext));
            }
        }
    }
}