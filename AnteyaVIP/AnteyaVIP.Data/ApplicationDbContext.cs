namespace AnteyaVIP.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    

    using Microsoft.AspNet.Identity.EntityFramework;
    using AnteyaVIP.Contracts;
    using AnteyaVIP.Contracts.CodeFirstConventions;
    using AnteyaVIP.Data.Migrations;
    using AnteyaVIP.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDigitalLibraryDbContext
    {
        public ApplicationDbContext()
            : this("DefaultConnection")
        {
        }

        public ApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        //public virtual IDbSet<Author> Authors { get; set; }

        //public virtual IDbSet<Comment> Comments { get; set; }

        //public virtual IDbSet<Genre> Genres { get; set; }

        //public virtual IDbSet<Like> Likes { get; set; }

        //public virtual IDbSet<Work> Works { get; set; }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new IsUnicodeAttributeConvention());

            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
