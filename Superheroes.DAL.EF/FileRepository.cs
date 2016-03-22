using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superheroes.Domain;

namespace Superheroes.DA.EF
{
    public class FileRepository : IFileRepository
    {
        public DbFile Add(DbFile file)
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                context.Files.Add(file);
                context.SaveChanges();
                return file;
            }
        }

        public DbFile Get(int id)
        {
            using (SuperheroesContext context = new SuperheroesContext())
            {
                return context.Files.Find(id);
            }
        }
    }
}
