using System.Linq.Expressions;

namespace ExaminationSystem.Data.Repository
{
    public interface IRepository<Entity>
    {
        void Add(Entity entity);
        public void SaveInclude(Entity entity, params string[] fields);
        void Delete(Entity entity);
        void HardDelete(Entity entity);
        IQueryable<Entity> Get();
        IQueryable<Entity> Get(Expression<Func<Entity , bool>> predicate);
        IQueryable<Entity> GetWithDeleted();
        Entity GetByID(int id);
        void SaveChanges();
        bool IsExist(int id);
    }
}
