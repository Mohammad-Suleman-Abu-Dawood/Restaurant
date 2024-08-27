
using Restaurant.Data;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class TransactionContactURepository : IRepository<TransactionContactU>
    {
        private readonly AppDbConttext db;

        public TransactionContactURepository(AppDbConttext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.TransactionContactU.Where(x => x.TransactionContactUId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.TransactionContactU.Update(data);
            db.SaveChanges();
        }

        public void Add(TransactionContactU Entity)
        {
            db.TransactionContactU.Add(Entity); 
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionContactU Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public TransactionContactU Find(int Id)
        {
            return db.TransactionContactU.SingleOrDefault(x => x.TransactionContactUId == Id);
        }

        public void Update(int Id, TransactionContactU Entity)
        {
            db.TransactionContactU.Update(Entity);
            db.SaveChanges();
        }

        public List<TransactionContactU> View()
        {
            return db.TransactionContactU.Where(x => x.IsDelete == false).ToList();
        }

        public List<TransactionContactU> ViewClient()
        {
            return db.TransactionContactU.Where(x => x.IsDelete == false && x.IsActive==true).ToList();
        }
    }
}
