namespace LostPeopleRegisterApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CustomDatabaseContext : DbContext
    {
        public CustomDatabaseContext()
            : base("name=CustomDatabaseContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
