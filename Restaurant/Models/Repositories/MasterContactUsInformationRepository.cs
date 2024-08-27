
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class MasterContactUsInformationRepository : IRepository<MasterContactUsInformation>
    {
        private readonly AppDbConttext db;

        public MasterContactUsInformationRepository(AppDbConttext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
           var data=db.MasterContactUsInformation.Where (x => x.MasterContactUsInformationId == Id ).SingleOrDefault();
            data.IsActive=!data.IsActive;
            data.EditDate = DateTime.Now;
            db.MasterContactUsInformation.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterContactUsInformation Entity)
        {
            db.MasterContactUsInformation.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterContactUsInformation Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public MasterContactUsInformation Find(int Id)
        {
          return  db.MasterContactUsInformation.SingleOrDefault(x=>x.MasterContactUsInformationId==Id);
        }

        public void Update(int Id, MasterContactUsInformation Entity)
        {
            db.MasterContactUsInformation.Update(Entity);
            db.SaveChanges();
        }

        public List<MasterContactUsInformation> View()
        {
            return db.MasterContactUsInformation.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterContactUsInformation> ViewClient()
        {
            return db.MasterContactUsInformation.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
