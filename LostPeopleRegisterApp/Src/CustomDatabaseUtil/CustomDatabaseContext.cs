using LostPeopleRegisterApp.Src.LostPersonUtil;
using LostPeopleRegisterApp.Src.LostPersonUtil.AdditionalDetails;
using LostPeopleRegisterApp.Src.LostPersonUtil.Address;
using LostPeopleRegisterApp.Src.LostPersonUtil.Image;
using LostPeopleRegisterApp.Src.AccountUtil;
using System.Data.Entity;

namespace LostPeopleRegisterApp.Src.CustomDatabaseUtil
{
    public partial class CustomDatabaseContext : DbContext
    {

        public DbSet<Account> accounts { get; set; }
        public DbSet<LostPerson> lostPeople { get; set; }

        public CustomDatabaseContext() : base("name=CustomDatabaseContext") {}


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelBuilderUtils modelBuilderUtils = new ModelBuilderUtils(modelBuilder);

            modelBuilderUtils.createInheritanceMapping<Account>("account");
            modelBuilder.Entity<Account>()
                .HasMany(x => x.lostPersonList)
                .WithRequired(x => x.account)
                .HasForeignKey(x => x.createdAccountId);


            modelBuilderUtils.createInheritanceMapping<LostPerson>("lost_person");
            modelBuilder.Entity<LostPerson>()
                .HasRequired(x => x.status)
                .WithRequiredPrincipal();

            modelBuilder.Entity<LostPerson>()
                .HasMany(x => x.images)
                .WithRequired(x => x.lostPerson)
                .HasForeignKey(x => x.lostPersonId);

            modelBuilder.Entity<LostPerson>()
                .HasMany(x => x.additionalDetails)
                .WithRequired(x => x.lostPerson)
                .HasForeignKey(x => x.lostPersonId);

            
            modelBuilder.Entity<LostPersonAddress>()
                .HasRequired(x => x.lostPerson)
                .WithRequiredPrincipal(x => x.address);

            modelBuilderUtils.createInheritanceMapping<LostPersonImage>("lost_person_image");
            modelBuilderUtils.createInheritanceMapping<LostPersonAdditionalDetail>("lost_person_additional_details");
            modelBuilderUtils.createInheritanceMapping<CityLostPersonAddress>("lost_person_address_city");
            modelBuilderUtils.createInheritanceMapping<VillageLostPersonAddress>("lost_person_address_village");
        }
    }
}
