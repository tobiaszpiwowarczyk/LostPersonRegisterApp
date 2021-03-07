using LostPeopleRegisterApp.Src.Util;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LostPeopleRegisterApp.Src.LostPersonUtil
{
    public sealed class LostPersonRepository : AbstractRepository<LostPerson>
    {
        private static LostPersonRepository instance;
        protected override DbSet<LostPerson> collection { get => this.context.lostPeople; }

        private LostPersonRepository() { }

        public static LostPersonRepository INSTANCE
        {
            get => instance != null ? instance : instance = new LostPersonRepository();
        }

        public List<LostPerson> findAll() => this.collection.ToList();
    }
}