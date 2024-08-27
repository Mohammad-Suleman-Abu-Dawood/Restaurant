
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterSliderRepository : IRepository<MasterSlider>
    {
        private readonly AppDbConttext db;

        public MasterSliderRepository(AppDbConttext db)
        {
            this.db = db;
        }

        public void Active(int Id)
        {
            var data = db.MasterSliders.Where(x => x.MasterSliderId == Id).SingleOrDefault();
            data.IsActive = !data.IsActive;
            data.EditDate = DateTime.Now;

            db.MasterSliders.Update(data);
            db.SaveChanges();
        }

        public void Add(MasterSlider Entity)
        {
            Entity.IsActive = true;
            Entity.IsDelete = false;
            db.MasterSliders.Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSlider Entity)
        {
            var data = Find(Id);
            data.IsDelete = true;
            data.IsActive = false;
            db.SaveChanges();
        }

        public MasterSlider Find(int Id)
        {
            var data = db.MasterSliders.SingleOrDefault(x => x.MasterSliderId == Id);

            return data;
        }

        public void Update(int Id, MasterSlider Entity)
        {

            db.MasterSliders.Update(Entity);
            db.SaveChanges();
        }

        public List<MasterSlider> View()
        {
            return db.MasterSliders.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSlider> ViewClient()
        {
            return db.MasterSliders.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
