
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterCategoryMenuRepository : IRepository<MasterCategoryMenu>
    {
        private readonly AppDbConttext db;

        public MasterCategoryMenuRepository(AppDbConttext db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.MasterCategoryMenus.Where(x => x.MasterCategoryMenuId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterCategoryMenus.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterCategoryMenu Entity)
        {
            Entity.CreateDate = DateTime.Now;
            Entity.IsActive = true;
            Entity.IsDelete = false;
            db.MasterCategoryMenus.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterCategoryMenu Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.EditDate = DateTime.Now;
            db.SaveChanges();
        }

        public MasterCategoryMenu Find(int Id)
        {
            var data = db.MasterCategoryMenus.SingleOrDefault(x => x.MasterCategoryMenuId == Id);

            return data;
        }

        public void Update(int Id, MasterCategoryMenu Entity)
        {


            Entity.CreateDate = DateTime.Now;
            db.MasterCategoryMenus.Update(Entity);
            Entity.IsDelete = false;
            Entity.IsActive = true;
            db.SaveChanges();
        }

        public List<MasterCategoryMenu> View()
        {
            return db.MasterCategoryMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterCategoryMenu> ViewClient()
        {
            return db.MasterCategoryMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
