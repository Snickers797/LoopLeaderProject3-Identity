using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using LoopLeader.Domain.Entities;
using LoopLeader.Domain.Abstract;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LoopLeader.Models;

namespace LoopLeader.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an Email Address")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                                    ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Must be less than 50 characters")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [StringLength(100, ErrorMessage = "Less than 100 characters")]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [StringLength(50, ErrorMessage = "Must be less than 50 characters")]
        [Display(Name = "City")]
        public string City { get; set; }

        [StringLength(20, ErrorMessage = "Must be less than 20 characters")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode must be 5 or 9 digits in length")]
        [RegularExpression(@"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z]\d[a-zA-Z]\d)$")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(65, ErrorMessage = "Must be less than 65 characters")]
        public string Country { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("LLDbContext")
        {
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
                .ToTable("Members");
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Members");
        }

        public class IdentityManager
        {
            public bool RoleExists(string name)
            {
                var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                return rm.RoleExists(name);
            }

            public bool CreateRole(string name)
            {
                var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                var idResult = rm.Create(new IdentityRole(name));
                return idResult.Succeeded;
            }

            public bool CreateUser(ApplicationUser user, string password)
            {
                var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var idResult = um.Create(user, password);
                return idResult.Succeeded;
            }

            public bool AddUserToRole(string userId, string roleName)
            {
                var um = new UserManager<ApplicationUser>( new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var idResult = um.AddToRole(userId, roleName);
                return idResult.Succeeded;
            }

            public void ClearUserRoles(string userId)
            {
                var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = um.FindById(userId);
                var currentRoles = new List<IdentityUserRole>();
                currentRoles.AddRange(user.Roles);
                foreach(var role in currentRoles)
                {
                    um.RemoveFromRole(userId, role.Role.Name);
                }
            }
        }

        public DbSet<Content> Content { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}