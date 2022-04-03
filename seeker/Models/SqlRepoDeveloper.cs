using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seeker.Models
{
    public class SqlRepoDeveloper : IDeveloper
    {
        private readonly AppDbContext context;
        public SqlRepoDeveloper(AppDbContext context)
        {
            this.context = context;
        }
        public Developer Add(Developer developer)
        {
            context.Developer.Add(developer);
            context.SaveChanges();
            return developer;
        }

        public Developer Delete(int Id)
        {
            Developer developer = context.Developer.Find(Id);
            if (developer != null)
            {
                context.Developer.Remove(developer);
                context.SaveChanges();
            }
            return developer;
        }

        public IEnumerable<Developer> GetAllDetails()
        {
            return context.Developer;
        }

        public Developer GetDeveloper(int Id)
        {
            return context.Developer.Find(Id);
        }

        public Developer Update(Developer developerChange)
        {
            var developer = context.Developer.Attach(developerChange);
            developer.State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return developerChange;
        }
    }
}
