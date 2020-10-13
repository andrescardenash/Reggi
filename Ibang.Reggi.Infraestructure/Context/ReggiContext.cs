using Ibang.Reggi.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ibang.Reggi.Infraestructure.Context
{
    public class ReggiContext : IdentityDbContext<User>
    {
        #region Properties
        public virtual DbSet<Activity> Activity { get; set; }

        public virtual DbSet<ActivityHours> ActivityHours { get; set; }
        #endregion

        #region Constructor
        public ReggiContext(DbContextOptions<ReggiContext> options) : base(options) { }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var guestRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "guest",
                NormalizedName = "guest"
            };

            builder.Entity<IdentityRole>().HasData(guestRole);

            base.OnModelCreating(builder);
        }
    }
}
