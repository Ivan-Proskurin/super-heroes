using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Superheroes.Domain;

namespace Superheroes.DA.EF
{
    public class TalentRepositoryEF : ITalentRepository
    {
        public void Add(SuperheroTalent talent)
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                if (talent.Superhero == null)
                {
                    talent.Superhero = context.Superheroes.Find(talent.OwnerId);
                    context.Talents.Add(talent);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                SuperheroTalent talent = context.Talents.
                    Where(t => t.TalentId == id).
                    Include(t => t.Image).
                    SingleOrDefault();

                if (talent != null)
                {
                    if (talent.Image != null)
                    {
                        context.Files.Remove(talent.Image);
                    }
                    context.Talents.Remove(talent);
                    context.SaveChanges();
                }
            }
        }

        public SuperheroTalent Get(int id)
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                return context.Talents.
                    Where(t => t.TalentId == id).
                    Include(t => t.Superhero).
                    SingleOrDefault();
            }
        }

        public List<SuperheroTalent> GetSuperheroTalents(int superheroId)
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                var query = from t in context.Talents
                            where t.OwnerId == superheroId
                            select t;
                return query.ToList();
            }
        }

        public void Update(SuperheroTalent talent)
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                SuperheroTalent dbTalent = context.Talents.
                    Where(t => t.TalentId == talent.TalentId).
                    Include(t => t.Image).
                    Include(t => t.Superhero).
                    SingleOrDefault();

                if (dbTalent != null)
                {
                    dbTalent.Name = talent.Name;
                    dbTalent.Details = talent.Details;
                    if (dbTalent.Image != null && talent.Image != null)
                    {
                        context.Files.Remove(dbTalent.Image);
                    }
                    if (talent.Image != null)
                    {
                        dbTalent.Image = talent.Image;
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
