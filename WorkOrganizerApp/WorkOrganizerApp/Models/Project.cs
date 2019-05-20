using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOrganizerApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
