using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LostPeopleRegisterApp.Src.CustomDatabaseUtil
{
    internal class ModelBuilderUtils
    {
        private DbModelBuilder modelBuilder { get; set; }

        public ModelBuilderUtils(DbModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        internal EntityTypeConfiguration<T> createInheritanceMapping<T>(string toTableName) where T : class
        {
            return this.modelBuilder.Entity<T>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable(toTableName);
            });
        }
    }
}