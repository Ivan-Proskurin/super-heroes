using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.DA
{
    public interface ISuperheroRepository
    {
        List<Superhero> GetSuperheroes();
        Superhero Get(int id);
        Superhero Add(Superhero hero);
        void Update(Superhero hero);
        void Delete(int id);
    }
}
