using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobTrackerApp.Data.Enums.JobApplicationEnums;

namespace JobTrackerApp.Models.CategoryUpdateModel
{
    public class CategoryUpdateModel
    {
        public int? CardId { get; set; }
        public JobApplicationCategory NewCategory { get; set; }

        public string DisplayNewCategory
        {
            get
            {
                return GetEnumDisplayName(NewCategory);
            }
        }

        private string GetEnumDisplayName(JobApplicationCategory newCategory)
        {
            var field = newCategory.GetType().GetField(newCategory.ToString());
            var displayAttribute = field?.GetCustomAttributes(typeof(DisplayOrderAttribute), false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault();

            return displayAttribute?.Name ?? newCategory.ToString();
        }
    }
}
