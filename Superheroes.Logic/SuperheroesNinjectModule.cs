using Ninject.Modules;
using Superheroes.DA;
using Superheroes.DA.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.Logic
{
    public class SuperheroesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISuperheroRepository>().To<SuperheroRepository>();
            this.Bind<ITalentRepository>().To<TalentRepository>();
            this.Bind<IFileRepository>().To<FileRepository>();
            this.Bind<SuperheroesBusinessLogic>().ToSelf();
        }
    }
}
