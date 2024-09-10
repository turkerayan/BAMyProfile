using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Entities.Configurations;
using BAMyProfileApp.Core.Enums;
using BAMyProfileApp.Entities.DbSets;
using BAMyProfileApp.Core.Entities.Interfaces;

namespace BAMyProfileApp.DataAccess.Contexts
{
    public class BAMyProfileAppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public const string ConnectionName = "BAMyProfileApp";
        public BAMyProfileAppDbContext(DbContextOptions<BAMyProfileAppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public BAMyProfileAppDbContext(DbContextOptions<BAMyProfileAppDbContext> options) : base(options)
        {

        }

        // DbSets
        public virtual DbSet<Example> Examples { get; set; }
        public virtual DbSet<Capability> Capability { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Cv> Cvs { get; set; }
        public virtual DbSet<EventStudent> EventStudents { get; set; }
        public virtual DbSet<ReferenceStudent> ReferenceStudents { get; set; }
        public virtual DbSet<StudentCertificate> StudentsCertificates { get; set; }
        public virtual DbSet<CapabilityStudent> CapabilityStudents { get; set; }
        public virtual DbSet<StudentTrainingProgram> StudentTrainingPrograms { get; set; }
        public virtual DbSet<StudentLanguage> StudentLanguages { get; set; }

        public virtual DbSet<StudentDepartment> StudentDepartments { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Benefit> Benefits { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<JobBenefit> JobBenefits { get; set; }
        public virtual DbSet<JobSkill> JobSkills { get; set; }


        public virtual DbSet<ApplicationInterview> ApplicationInterviews { get; set; }
        public virtual DbSet<ApplicationInterviewer> ApplicationInterviewers { get; set; }
        public virtual DbSet<ContactPerson> ContactPeople { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyContactInformation> CompanyContactInformations { get; set; }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<JobCandidate> JobCandidate { get; set; }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration).Assembly);



            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            SetBaseProperties();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetBaseProperties()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            //var user = _httpContextAccessor.HttpContext!.User;

            //var userId = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "NotFound-User"; ;
            var userId = "NotFound-User";

            foreach (var entry in entries)
            {
                SetIfAdded(entry, userId);
                SetIfModified(entry, userId);
                SetIfDeleted(entry, userId);
            }
        }

        private void SetIfDeleted(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State is not EntityState.Deleted)
            {
                return;
            }

            if (entry.Entity is not AuditableEntity entity)
            {
                return;
            }

            entry.State = EntityState.Modified;

            entity.Status = Status.Deleted;
            entity.DeletedDate = DateTime.Now;
            entity.DeletedBy = userId;
        }

        private void SetIfModified(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State is EntityState.Modified)
            {
                if (entry.Entity.Status == Status.Passive)
                    entry.Entity.Status = Status.Passive;
                if (entry.Entity.Status == Status.Active)
                    entry.Entity.Status = Status.Active;
            }
            entry.Entity.ModifiedBy = userId;
            entry.Entity.ModifiedDate = DateTime.Now;
        }

        private void SetIfAdded(EntityEntry<BaseEntity> entry, string userId)
        {
            if (entry.State is not EntityState.Added)
            {
                return;
            }
            entry.Entity.Status = Status.Active;
            entry.Entity.CreatedBy = userId;
            entry.Entity.CreatedDate = DateTime.Now;
        }
    }
}
