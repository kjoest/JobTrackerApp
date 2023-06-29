using JobTrackerApp.Data.JobApplication;
using JobTrackerApp.Models.CategoryUpdateModel;
using JobTrackerApp.Models.JobApplicationModels;
using JobTrackerApp.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static JobTrackerApp.Data.Enums.JobApplicationEnums;

namespace JobTrackerApp.Services.JobApplicationServices
{
    public class JobApplicationService
    {
        private readonly Guid _userId;

        public JobApplicationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateJobApplication(JobApplicationCreate model)
        {
            var entity = new JobApplication()
            {
                OwnerId = _userId,
                JobTitle = model.JobTitle,
                CompanyName = model.ComapnyName,
                ApplicationMethod = model.ApplicationMethod,
                ApplicationMaterials = model.ApplicationMaterials,
                ContactPerson = model.ContactPerson,
                ContactInformation = model.ContactInformation,
                ApplicationNotes = model.ApplicationNotes,
                Category = model.Category,
                ApplicationDate = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.JobApplications.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JobApplicationListDetail> GetJobApplications()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .JobApplications
                    .Where(j => j.OwnerId == _userId)
                    .Select(
                    j => new JobApplicationListDetail
                    {
                        JobApplicationId = j.JobApplicationId,
                        JobTitle = j.JobTitle,
                        CompanyName = j.CompanyName,
                        Category = j.Category
                    });

                return query.ToArray();
            }
        }

        public JobApplicationDetail GetJobApplicationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .JobApplications
                    .Single(j => j.JobApplicationId == id && j.OwnerId == _userId);

                return new JobApplicationDetail
                {
                    JobApplicationId = entity.JobApplicationId,
                    JobTitle = entity.JobTitle,
                    CompanyName = entity.CompanyName,
                    ApplicationMethod = entity.ApplicationMethod,
                    ApplicatonMaterials = entity.ApplicationMaterials,
                    ContactPerson = entity.ContactPerson,
                    ContactInformation = entity.ContactInformation,
                    ApplicationNotes = entity.ApplicationNotes,
                    ApplicationDate = entity.ApplicationDate,
                    Category = entity.Category,
                    ModifiedDate = entity.ModifiedDate
                };
            }
        }

        public bool UpdateJobApplication(JobApplicationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .JobApplications
                    .Single(j => j.JobApplicationId == model.JobApplicationId && j.OwnerId == _userId);

                entity.ApplicationMaterials = model.ApplicationMaterials;
                entity.ContactPerson = model.ContactPerson;
                entity.ContactInformation = model.ContactInformation;
                entity.ApplicationNotes = model.ApplicationNotes;
                entity.Category = model.Category;
                entity.ModifiedDate = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateCategory(int jobApplicationId, string newCategory)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .JobApplications
                    .SingleOrDefault(j => j.JobApplicationId == jobApplicationId && j.OwnerId == _userId);

                if (entity != null)
                {
                    entity.Category = (JobApplicationCategory)Enum.Parse(typeof(JobApplicationCategory), newCategory);
                    entity.ModifiedDate = DateTimeOffset.UtcNow;
                    return ctx.SaveChanges() == 1;
                }
            }

            return false;
        }

        public bool DeleteJobApplication(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .JobApplications
                    .Single(j => j.JobApplicationId == id && j.OwnerId == _userId);

                ctx.JobApplications.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
