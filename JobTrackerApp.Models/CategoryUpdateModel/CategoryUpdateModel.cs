using System;
using System.Collections.Generic;
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
    }
}
