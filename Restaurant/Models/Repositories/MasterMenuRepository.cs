
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        private readonly AppDbConttext db;

        public MasterMenuRepository(AppDbConttext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.MasterMenu.Where(x => x.MasterMenuId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterMenu.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterMenu Entity)
        {
            db.MasterMenu.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterMenu Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public MasterMenu Find(int Id)
        {
            return db.MasterMenu.SingleOrDefault(x => x.MasterMenuId == Id);
        }

        public void Update(int Id, MasterMenu Entity)
        {
            db.MasterMenu.Update(Entity);
            db.SaveChanges();
        }

        public List<MasterMenu> View()
        {
            return db.MasterMenu.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterMenu> ViewClient()
        {
            return db.MasterMenu.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
