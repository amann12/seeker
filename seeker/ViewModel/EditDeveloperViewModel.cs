using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seeker.ViewModel
{
    public class EditDeveloperViewModel:DeveloperViewModel
    {
        public int Id{ get; set; }
        public string PhotoPath { get; set; }
    }
}
