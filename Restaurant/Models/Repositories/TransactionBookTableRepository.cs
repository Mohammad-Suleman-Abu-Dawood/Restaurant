
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class TransactionBookTableRepository : IRepository<TransactionBookTable>
    {
        private readonly AppDbConttext db;

        public TransactionBookTableRepository(AppDbConttext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.TransactionBookTable.Where(x => x.TransactionBookTableId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.TransactionBookTable.Update(data);
            db.SaveChanges();
        }

        public void Add(TransactionBookTable Entity)
        {
          db.TransactionBookTable.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionBookTable Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public TransactionBookTable Find(int Id)
        {
            return db.TransactionBookTable.SingleOrDefault(x => x.TransactionBookTableId == Id);
        }

        public void Update(int Id, TransactionBookTable Entity)
        {
            db.TransactionBookTable.Update(Entity);
            db.SaveChanges();
        }

        public List<TransactionBookTable> View()
        {
            return db.TransactionBookTable.Where(x => x.IsDelete == false).ToList();
        }

        public List<TransactionBookTable> ViewClient()
        {
            return db.TransactionBookTable.Where(x => x.IsDelete == false && x.IsActive==true).ToList();
        }
    }
}
