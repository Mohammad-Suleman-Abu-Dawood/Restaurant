
using Restaurant.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurant.Models.Repositories
{
    public class TransactionNewsletterRepository : IRepository<TransactionNewsletter>
    {
        private readonly AppDbConttext db;

        public TransactionNewsletterRepository(AppDbConttext db)
        {
            this.db = db;
        }
        public void Active(int Id)
        {
            var data = db.TransactionNewsletter.Where(x => x.TransactionNewsletterId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;
            data.EditId = "1";
            db.TransactionNewsletter.Update(data);
            db.SaveChanges();
        }

        public void Add(TransactionNewsletter Entity)
        {
           db.TransactionNewsletter.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, TransactionNewsletter Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            db.SaveChanges();
        }

        public TransactionNewsletter Find(int Id)
        {
            return db.TransactionNewsletter.SingleOrDefault(x => x.TransactionNewsletterId == Id);
        }

        public void Update(int Id, TransactionNewsletter Entity)
        {
            db.TransactionNewsletter.Update(Entity);
            db.SaveChanges();
        }

        public List<TransactionNewsletter> View()
        {
            return db.TransactionNewsletter.Where(x => x.IsDelete == false).ToList();
        }

        public List<TransactionNewsletter> ViewClient()
        {
            return db.TransactionNewsletter.Where(x => x.IsDelete == false && x.IsActive==true).ToList();
        }
    }
}
