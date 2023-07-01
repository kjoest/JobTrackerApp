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
            ActiveApplications,

            [Display(Name = "Interview Scheduled")]
            [DisplayOrder(2)]
            InterviewScheduled,

            [Display(Name = "Rejected Application")]
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
