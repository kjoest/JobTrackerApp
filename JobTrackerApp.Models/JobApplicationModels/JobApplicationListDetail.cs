using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobTrackerApp.Data.Enums.JobApplicationEnums;

namespace JobTrackerApp.Models.JobApplicationModels
{
    public class JobApplicationListDetail
    {
        public int JobApplicationId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public JobApplicationCategory Category { get; set; }

        public string DisplayCategory
        {
            get
            {
                return GetEnumDisplayName(Category);
            }
        }

        private string GetEnumDisplayName (JobApplicationCategory category)
        {
            var field = category.GetType().GetField(category.ToString());
            var displayAttribute = field?.GetCustomAttributes(typeof(DisplayAttribute), false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault();

            return displayAttribute?.Name ?? category.ToString();
        }
    }
}
