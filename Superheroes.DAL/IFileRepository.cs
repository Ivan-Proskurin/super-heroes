using Superheroes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.DA
{
    public interface IFileRepository
    {
        DbFile Add(DbFile file);
        DbFile Get(int id);
    }
}
