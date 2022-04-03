using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seeker.Models
{
    public interface IDeveloper
    {
        //Fetch Single Details
        Developer GetDeveloper(int Id);
        //Fetch All Details
        IEnumerable<Developer> GetAllDetails();
        Developer Add(Developer developer);
        Developer Delete(int Id);
        Developer Update(Developer developerChange);
    }
}
