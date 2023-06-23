using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApp.Models.JobApplicationModels
{
    public class JobApplicationListDetail
    {
        public int JobApplicationId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string ApplicationMethod { get; set; }
        public string ApplicationMaterials { get; set; }
        public string ContactPerson { get; set; }
        public string ContactInformation { get; set; }
        public string ApplicationNotes { get; set; }

        public DateTimeOffset ApplicationDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
