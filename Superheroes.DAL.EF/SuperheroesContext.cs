using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Superheroes.Domain;

namespace Superheroes.DA.EF
{
    public class SuperheroesContext : IdentityDbContext<SuperheroAppUser>
    {
        public SuperheroesContext()
            : base("SuperheroesDB", throwIfV1Schema: false)
        {
        }

        public static SuperheroesContext Create()
        {
            return new SuperheroesContext();
        }

        public DbSet<Superhero> Superheroes { get; set; }

        public DbSet<SuperheroTalent> Talents { get; set; }

        public DbSet<DbFile> Files { get; set; }
    }
}
