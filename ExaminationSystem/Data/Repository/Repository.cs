
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ExaminationSystem.Data.Repository
{
    public class Repository<Entity> : IRepository<Entity> where Entity : BaseModel 
    {
        Context _context;
        DbSet<Entity> _dbset;

        public Repository()
        {
            _context = new Context();
            _dbset = _context.Set<Entity>();
        }
        public void Add(Entity entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = 55;  
            
            _dbset.Add(entity);
        }
        public void SaveInclude(Entity entity, params string[] fields)
        {
            var local = _dbset.Local.FirstOrDefault(x => x.ID == entity.ID);

            EntityEntry entry = null;

            if (local is null)
            {
                entry = _context.Entry(entity);
            }
            else
            {
                entry = _context.ChangeTracker.Entries<Entity>()
                    .FirstOrDefault(x => x.Entity.ID == entity.ID);
            }
            foreach (var property in entry.Properties)
            {
                if (fields.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;
                }
                else if(property.Metadata.Name == nameof(entity.UpdatedAt))
                {
                    property.CurrentValue = DateTime.Now;
                    property.IsModified = true;
                }
                else if (property.Metadata.Name == nameof(entity.UpdatedBy))
                {
                    property.CurrentValue = 99;
                    property.IsModified = true;
                }
            }

        }

        public void Delete(Entity entity)
        {
            entity.Deleted = true;
            SaveInclude(entity,nameof(entity.Deleted));
        }

        public void HardDelete(Entity entity)
        {
            _dbset.Remove(entity);
        }

        public IQueryable<Entity> Get()
        {
            return _dbset.Where(x=> x.Deleted==false);
        }
        public IQueryable<Entity> GetWithDeleted()
        {
            return _dbset;
        }

        public Entity GetByID(int id)
        {
            return Get().FirstOrDefault(x=>x.ID==id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
