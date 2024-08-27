
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class MasterPartnerRepository : IRepository<MasterPartner>
    {
        private readonly AppDbConttext db;

        public MasterPartnerRepository(AppDbConttext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.MasterPartner.Where(x => x.MasterPartnerId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.MasterPartner.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterPartner Entity)
        {
           db.MasterPartner.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterPartner Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public MasterPartner Find(int Id)
        {
            return db.MasterPartner.SingleOrDefault(x => x.MasterPartnerId == Id);
        }

        public void Update(int Id, MasterPartner Entity)
        {
            db.MasterPartner.Update(Entity);
            db.SaveChanges();
        }

        public List<MasterPartner> View()
        {
            return db.MasterPartner.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterPartner> ViewClient()
        {
            return db.MasterPartner.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
