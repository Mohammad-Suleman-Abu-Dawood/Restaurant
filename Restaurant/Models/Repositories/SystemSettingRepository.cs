
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class SystemSettingRepository : IRepository<SystemSetting>
    {
        private readonly AppDbConttext db;

        public SystemSettingRepository(AppDbConttext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.SystemSetting.Where(x => x.SystemSettingId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.SystemSetting.Update(data);
            db.SaveChanges();
        }

        public void Add(SystemSetting Entity)
        {
            db.SystemSetting.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, SystemSetting Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public SystemSetting Find(int Id)
        {
            return db.SystemSetting.SingleOrDefault(x => x.SystemSettingId == Id);
        }

        public void Update(int Id, SystemSetting Entity)
        {
            db.SystemSetting.Update(Entity);
            db.SaveChanges();
        }

        public List<SystemSetting> View()
        {
            return db.SystemSetting.Where(x => x.IsDelete == false).ToList();
        }

        public List<SystemSetting> ViewClient()
        {
            return db.SystemSetting.Where(x => x.IsDelete == false && x.IsActive==true).ToList();
        }
    }
}
