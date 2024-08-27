
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class MasterSocialMediumRepository : IRepository<MasterSocialMedium>
    {
        private readonly AppDbConttext db;

        public MasterSocialMediumRepository(AppDbConttext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.MasterSocialMedium.Where(x => x.MasterSocialMediumId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.MasterSocialMedium.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterSocialMedium Entity)
        {
           db.MasterSocialMedium.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSocialMedium Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public MasterSocialMedium Find(int Id)
        {
            return db.MasterSocialMedium.SingleOrDefault(x => x.MasterSocialMediumId == Id);
        }

        public void Update(int Id, MasterSocialMedium Entity)
        {
            db.MasterSocialMedium.Update(Entity);
            db.SaveChanges();
        }

        public List<MasterSocialMedium> View()
        {
            return db.MasterSocialMedium.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSocialMedium> ViewClient()
        {
            return db.MasterSocialMedium.Where(x => x.IsDelete == false && x.IsActive==true ).ToList();
        }
    }
}
