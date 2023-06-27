using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTrackerApp.Data.Enums
{
    public class JobApplicationEnums
    {
        public enum JobApplicationCategory
        {
            [Display(Name = "Interview Scheduled")]
            [DisplayOrder(1)]
            InterviewedScheduled,

            [Display(Name = "Active Application")]
            [DisplayOrder(2)]
            ActiveApplication,

            [Display(Name = "Rejected Applications")]
            [DisplayOrder(3)]
            RejectedApplications
        }

        public class DisplayOrderAttribute: Attribute
        {
            public int Order { get; }

            public DisplayOrderAttribute(int order)
            {
                Order = order;
            }
        }
    }
}
