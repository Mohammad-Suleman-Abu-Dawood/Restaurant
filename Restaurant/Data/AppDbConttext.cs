using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Data
{
    public class AppDbConttext:IdentityDbContext
    {
        public AppDbConttext(DbContextOptions<AppDbConttext> options) : base(options)
        {

        }
        public virtual DbSet<MasterCategoryMenu> MasterCategoryMenus { get; set; }

        public virtual DbSet<MasterContactUsInformation> MasterContactUsInformation { get; set; }

        public virtual DbSet<MasterItemMenu> MasterItemMenus { get; set; }

        public virtual DbSet<MasterMenu> MasterMenu { get; set; }

        public virtual DbSet<MasterOffer> MasterOffer { get; set; }

        public virtual DbSet<MasterPartner> MasterPartner { get; set; }

        public virtual DbSet<MasterService> MasterService { get; set; }

        public virtual DbSet<MasterSlider> MasterSliders { get; set; }

        public virtual DbSet<MasterSocialMedium> MasterSocialMedium { get; set; }

        public virtual DbSet<MasterWorkingHour> MasterWorkingHour { get; set; }

        public virtual DbSet<SystemSetting> SystemSetting { get; set; }

        public virtual DbSet<TransactionBookTable> TransactionBookTable { get; set; }

        public virtual DbSet<TransactionContactU> TransactionContactU { get; set; }

        public virtual DbSet<TransactionNewsletter> TransactionNewsletter { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
    }
}
