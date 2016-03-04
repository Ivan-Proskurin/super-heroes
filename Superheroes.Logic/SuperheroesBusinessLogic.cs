using Ninject;
using Superheroes.DA;
using Superheroes.DA.EF;
using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.Logic
{
    public class SuperheroesBusinessLogic
    {
        [Inject]
        public ISuperheroRepository Superheroes { get; set; }

        [Inject]
        public ITalentRepository Talents { get; set; }

        [Inject]
        public IFileRepository Files { get; set; }

        public List<Superhero> GetSuperheroes()
        {
            return Superheroes.GetSuperheroes();
        }

        public Superhero GetSuperhero(int id)
        {
            return Superheroes.Get(id);
        }

        public List<SuperheroTalent> GetSuperheroTalents(int superheroId)
        {
            return Talents.GetSuperheroTalents(superheroId);
        }

        public Superhero AddSuperhero(Superhero hero)
        {
            return Superheroes.Add(hero);
        }

        public DbFile GetFile(int id)
        {
            return Files.Get(id);
        }

        public void UpdateSuperhero(Superhero hero)
        {
            Superheroes.Update(hero);
        }

        public void DeleteSuperhero(int id)
        {
            Superheroes.Delete(id);
        }

        public SuperheroTalent GetSuperheroTalent(int id)
        {
            return Talents.Get(id);
        }

        public void UpdateTalent(SuperheroTalent talent)
        {
            Talents.Update(talent);
        }

        public SuperheroTalent AddSuperheroTalent(SuperheroTalent talent)
        {
            Talents.Add(talent);
            return talent;
        }

        public void DeleteSuperheroTalent(SuperheroTalent talent)
        {
            Talents.Delete(talent.TalentId);
        }
    }
}
