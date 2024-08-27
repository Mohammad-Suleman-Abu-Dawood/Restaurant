
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class MasterWorkingHourRepository : IRepository<MasterWorkingHour>
    {
        private readonly AppDbConttext db;

        public MasterWorkingHourRepository(AppDbConttext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.MasterWorkingHour.Where(x => x.MasterWorkingHourId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.MasterWorkingHour.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterWorkingHour Entity)
        {
          db.MasterWorkingHour.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterWorkingHour Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public MasterWorkingHour Find(int Id)
        {
            return db.MasterWorkingHour.SingleOrDefault(x => x.MasterWorkingHourId == Id);
        }

        public void Update(int Id, MasterWorkingHour Entity)
        {
            db.MasterWorkingHour.Update(Entity);
            db.SaveChanges();
        }

        public List<MasterWorkingHour> View()
        {
            return db.MasterWorkingHour.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterWorkingHour> ViewClient()
        {
            return db.MasterWorkingHour.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
