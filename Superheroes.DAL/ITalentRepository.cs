using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.DA
{
    public interface ITalentRepository
    {
        SuperheroTalent Get(int id);
        void Update(SuperheroTalent talent);
        void Delete(int id);
        void Add(SuperheroTalent talent);
        List<SuperheroTalent> GetSuperheroTalents(int superheroId);
    }
}
