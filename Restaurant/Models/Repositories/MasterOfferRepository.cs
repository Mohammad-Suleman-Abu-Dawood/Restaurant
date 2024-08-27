
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class MasterOfferRepository : IRepository<MasterOffer>
    {
        private readonly AppDbConttext db;

        public MasterOfferRepository(AppDbConttext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.MasterOffer.Where(x => x.MasterOfferId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.MasterOffer.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterOffer Entity)
        {
           db.MasterOffer.Add(Entity);  
            db.SaveChanges();
        }

        public void Delete(int Id, MasterOffer Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public MasterOffer Find(int Id)
        {
            return db.MasterOffer.SingleOrDefault(x => x.MasterOfferId == Id);
        }

        public void Update(int Id, MasterOffer Entity)
        {
            db.MasterOffer.Update(Entity);
            db.SaveChanges();
        }

        public List<MasterOffer> View()
        {
            return db.MasterOffer.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterOffer> ViewClient()
        {
            return db.MasterOffer.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
