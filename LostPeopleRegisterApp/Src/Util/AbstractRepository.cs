using LostPeopleRegisterApp.Src.CustomDatabaseUtil;
using System.Data.Entity;
using System.Linq;

namespace LostPeopleRegisterApp.Src.Util
{
    public abstract class AbstractRepository<T> where T : BaseEntity
    {
        protected CustomDatabaseContext context { get; private set; }
        protected abstract DbSet<T> collection { get; }

        public AbstractRepository()
        {
            this.context = new CustomDatabaseContext();
        }

        public virtual T findById(int id) => this.collection.Where(x => x.id == id).FirstOrDefault(null);
        public virtual void create(T obj) => this.collection.Add(obj);

        public virtual void update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}