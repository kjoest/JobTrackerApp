using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static JobTrackerApp.Data.Enums.JobApplicationEnums;

namespace JobTrackerApp.Models.JobApplicationModels
{
    public class JobApplicationDetail
    {
        public int JobApplicationId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string ApplicationMethod { get; set; }
        public string ApplicatonMaterials { get; set; }
        public string ContactPerson { get; set; }
        public string ContactInformation { get; set; }
        public string ApplicationNotes { get; set; }
        public JobApplicationCategory Category { get; set; }

        public DateTimeOffset ApplicationDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
