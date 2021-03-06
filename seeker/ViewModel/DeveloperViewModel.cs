using Microsoft.AspNetCore.Http;
using seeker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seeker.ViewModel
{
    public class DeveloperViewModel
    {
        public int Id { get; set; }
        public string devName { get; set; }
        public string devEmail { get; set; }
        public long devPhoneNumber { get; set; }
        public country? devFrom { get; set; }
        public string devAbout { get; set; }
        public string devProject { get; set; }
        public string devGitHub { get; set; }
        public IFormFile Photo { get; set; }
    }
}
