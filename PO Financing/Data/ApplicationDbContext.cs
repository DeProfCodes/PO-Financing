using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PO_Financing.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PO_Financing.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
         IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
         IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private AuthenticationStateProvider _authenticationStateProvider;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, AuthenticationStateProvider stateProvider) : base(options)
        {
            _authenticationStateProvider = stateProvider;
        }

        public override int SaveChanges()
        {
            var stateProvider = Task.Run(() => _authenticationStateProvider.GetAuthenticationStateAsync()).Result;
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityBase && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((EntityBase)entityEntry.Entity).DateModified = DateTime.Now;
                ((EntityBase)entityEntry.Entity).CreatedBy = stateProvider.User.Identity.Name;

                if (entityEntry.State == EntityState.Added)
                {
                    ((EntityBase)entityEntry.Entity).DateCreated = DateTime.Now;
                    ((EntityBase)entityEntry.Entity).CreatedBy = stateProvider.User.Identity.Name;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            modelBuilder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            //TODO: Add all the constraints on the new entities
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        //Application Entities
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ApplicationDocument> ApplicationDocuments { get; set; }
        public DbSet<FundingApplication> FundingApplications { get; set; }
        public DbSet<PersonalDetail> PersonalDetails { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLegalEntity> PurchaseOrderLegalEntities { get; set; }


    }
}
