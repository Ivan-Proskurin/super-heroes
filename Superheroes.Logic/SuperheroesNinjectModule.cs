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
            this.Bind<ISuperheroRepository>().To<SuperheroRepositoryEF>();
            this.Bind<ITalentRepository>().To<TalentRepositoryEF>();
            this.Bind<IFileRepository>().To<FileRepositoryEF>();
            this.Bind<SuperheroesBusinessLogic>().ToSelf();
        }
    }
}
