
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterItemMenuRepository : IRepository<MasterItemMenu>
    {
        private readonly AppDbConttext db;

        public MasterItemMenuRepository(AppDbConttext db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.MasterItemMenus.Where(x => x.MasterItemMenuId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;

            db.MasterItemMenus.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterItemMenu Entity)
        {
            Entity.CreateDate = DateTime.Now;

            Entity.IsActive = true;
            Entity.IsDelete = false;

            db.MasterItemMenus.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterItemMenu Entity)
        {

            Entity.EditDate = DateTime.Now;
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public MasterItemMenu Find(int Id)
        {
            var data = db.MasterItemMenus.SingleOrDefault(x => x.MasterItemMenuId == Id);

            return data;
        }

        public void Update(int Id, MasterItemMenu Entity)
        {

            Entity.EditDate = DateTime.Now;
            Entity.IsActive = true;
            Entity.IsDelete = false;

            db.MasterItemMenus.Update(Entity);
            db.SaveChanges();
        }

        public List<MasterItemMenu> View()
        {
            return db.MasterItemMenus.Include(z => z.MasterCategoryMenu).Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterItemMenu> ViewClient()
        {
            return db.MasterItemMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
