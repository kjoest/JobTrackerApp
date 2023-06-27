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
            [Display(Name = "Active Application")]
            [DisplayOrder(1)]
            ActiveApplication,

            [Display(Name = "Interview Scheduled")]
            [DisplayOrder(2)]
            InterviewedScheduled,

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
