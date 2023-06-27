using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobTrackerApp.Data.Enums.JobApplicationEnums;

namespace JobTrackerApp.Data.JobApplication
{
    public class JobApplication
    {
        public int JobApplicationId { get; set; }
        public Guid OwnerId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string ApplicationMethod { get; set; }
        public string ApplicationMaterials { get; set; }
        public string ContactPerson { get; set; }
        public string ContactInformation { get; set; }
        public string ApplicationNotes { get; set; }

        public JobApplicationCategory Category { get; set; }

        public DateTimeOffset ApplicationDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
