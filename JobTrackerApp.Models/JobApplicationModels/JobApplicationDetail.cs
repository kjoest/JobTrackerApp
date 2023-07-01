 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static JobTrackerApp.Data.Enums.JobApplicationEnums;

namespace JobTrackerApp.Models.JobApplicationModels
{
    public class JobApplicationDetail
    {
        [DisplayName("Job Application ID: ")]
        public int JobApplicationId { get; set; }
        [DisplayName("Job Title: ")]
        public string JobTitle { get; set; }
        [DisplayName("Company Name: ")]
        public string CompanyName { get; set; }
        [DisplayName("Application Method: ")]
        public string ApplicationMethod { get; set; }
        [DisplayName("Application Materials: ")]
        public string ApplicatonMaterials { get; set; }
        [DisplayName("Contact Person: ")]
        public string ContactPerson { get; set; }
        [DisplayName("Contact Person Information: ")]
        public string ContactInformation { get; set; }
        [DisplayName("Application Notes: ")]
        public string ApplicationNotes { get; set; }
        public JobApplicationCategory Category { get; set; }

        public string DisplayCategory
        {
            get
            {
                return GetEnumDisplayName(Category);
            }
        }

        private string GetEnumDisplayName(JobApplicationCategory category)
        {
            var field = category.GetType().GetField(category.ToString());
            var displayAttribute = field?.GetCustomAttributes(typeof(DisplayAttribute), false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault();

            return displayAttribute?.Name ?? category.ToString();
        }


        [DisplayName("Date of Application: ")]
        public DateTimeOffset ApplicationDate { get; set; }
        [DisplayName("Application Modified Date: ")]
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
