using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superheroes.Domain;
using System.Data.Entity;

namespace Superheroes.DA.EF
{
    public class SuperheroRepositoryEF : ISuperheroRepository
    {
        public Superhero Get(int id)
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                var query = from h in context.Superheroes
                            where h.SuperheroId == id
                            select h;
                return query.SingleOrDefault();
            }
        }

        public List<Superhero> GetSuperheroes()
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                return context.Superheroes.ToList<Superhero>();
            }
        }

        public Superhero Add(Superhero hero)
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                context.Superheroes.Add(hero);
                context.SaveChanges();
            }
            return hero;
        }

        public void Update(Superhero hero)
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                Superhero dbHero =
                    context.Superheroes.
                    Where(h => h.SuperheroId == hero.SuperheroId).
                    Include(h => h.Image).
                    SingleOrDefault();

                if (dbHero != null)
                {
                    dbHero.Name = hero.Name;
                    dbHero.Details = hero.Details;
                    dbHero.HeroLevel = hero.HeroLevel;
                    if (dbHero.Image != null && hero.Image != null)
                    {
                        context.Files.Remove(dbHero.Image);
                        dbHero.Image = null;
                    }
                    if (hero.Image != null)
                    {
                        dbHero.Image = hero.Image;
                    }
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                Superhero hero = context.Superheroes.
                    Where(h => h.SuperheroId == id).
                    Include(h => h.Image).
                    SingleOrDefault();

                if (hero != null)
                {
                    if (hero.Image != null)
                    {
                        context.Files.Remove(hero.Image);
                    }

                    List<SuperheroTalent> talents = context.Talents.
                        Where(t => t.OwnerId == hero.SuperheroId).
                        Include(t => t.Image).ToList();

                    foreach (SuperheroTalent talent in talents)
                    {
                        if (talent.Image != null)
                        {
                            context.Files.Remove(talent.Image);
                        }
                    }
                    context.Superheroes.Remove(hero);
                    context.SaveChanges();
                }
            }
        }
    }
}
