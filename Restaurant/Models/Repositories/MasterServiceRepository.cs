
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class MasterServiceRepository : IRepository<MasterService>
    {
        private readonly AppDbConttext db;

        public MasterServiceRepository(AppDbConttext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.MasterService.Where(x => x.MasterServiceId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.MasterService.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterService Entity)
        {
           db.MasterService.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterService Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public MasterService Find(int Id)
        {
            return db.MasterService.SingleOrDefault(x => x.MasterServiceId == Id);
        }

        public void Update(int Id, MasterService Entity)
        {
            db.MasterService.Update(Entity);
            db.SaveChanges();
        }

        public List<MasterService> View()
        {
            return db.MasterService.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterService> ViewClient()
        {
            return db.MasterService.Where(x => x.IsDelete == false && x.IsActive==true).ToList(); ;
        }
    }
}
