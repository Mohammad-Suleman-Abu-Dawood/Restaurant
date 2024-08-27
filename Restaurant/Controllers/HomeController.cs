using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<MasterSlider> MasterSlider { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }
        public IRepository<MasterService> MasterService { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformations { get; }
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<TransactionBookTable> TransactionBookTables { get; }
        public IRepository<MasterOffer> MasterOffer { get; }
        public IRepository<MasterPartner> MasterPartners { get; }
        public IRepository<MasterWorkingHour> MasterWorkingHours { get; }
        public IRepository<TransactionContactU> TransactionContactUss { get; }
        public IRepository< MasterSocialMedium> MasterSocialMedias { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenus { get; }
        public IRepository<FeedBack> FeedBack { get; }

        public HomeController(IRepository<MasterMenu> _MasterMenu
            , IRepository<MasterSlider> _MasterSlider
            , IRepository<SystemSetting> _SystemSetting
            , IRepository<TransactionNewsletter> _TransactionNewsletter
            , IRepository<MasterService> _MasterService
            , IRepository<MasterContactUsInformation> MasterContactUsInformations,
            IRepository<MasterItemMenu> MasterItemMenu
            , IRepository<TransactionBookTable> TransactionBookTables
            , IRepository<MasterOffer> MasterOffer
            , IRepository<MasterPartner> MasterPartners
            , IRepository<MasterWorkingHour> MasterWorkingHours
            , IRepository<TransactionContactU> TransactionContactUss
            , IRepository<MasterSocialMedium> MasterSocialMedias
            , IRepository<MasterCategoryMenu> MasterCategoryMenus
            , IRepository<FeedBack> FeedBack

            )
        {
            MasterMenu = _MasterMenu;
            MasterSlider = _MasterSlider;
            SystemSetting = _SystemSetting;
            TransactionNewsletter = _TransactionNewsletter;
            MasterService = _MasterService;
            this.MasterContactUsInformations = MasterContactUsInformations;
            this.MasterItemMenu = MasterItemMenu;
            this.TransactionBookTables = TransactionBookTables;
            this.MasterOffer = MasterOffer;
            this.MasterPartners = MasterPartners;
            this.MasterWorkingHours = MasterWorkingHours;
            this.TransactionContactUss = TransactionContactUss;
            this.MasterSocialMedias = MasterSocialMedias;
            this.MasterCategoryMenus = MasterCategoryMenus;
            this.FeedBack = FeedBack;
        }


        public IActionResult Index()
        {
            var data = new HomeModel
            {
                ListMasterMenu = MasterMenu.ViewClient().ToList(),
                ListMasterSlider = MasterSlider.ViewClient().ToList(),
                SystemSetting = SystemSetting.ViewClient().SingleOrDefault(),
                ListMasterContactUsInformation = MasterContactUsInformations.ViewClient(),
                ListMasterItemMenu = MasterItemMenu.ViewClient().ToList(),
                MasterOffers = MasterOffer.ViewClient().SingleOrDefault(),
                ListMasterPartner = MasterPartners.ViewClient(),
                ListMasterWorkingHour = MasterWorkingHours.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedias.ViewClient(),
                ListFeedBack = FeedBack.ViewClient(),
            };
            return View(data);
        }


        public IActionResult About()
        {
            var data = new HomeModel
            {
                ListMasterMenu = MasterMenu.ViewClient().ToList(),
                SystemSetting = SystemSetting.ViewClient().SingleOrDefault(),
                ListMasterService = MasterService.ViewClient().ToList(),
                ListMasterContactUsInformation = MasterContactUsInformations.ViewClient(),
                ListMasterWorkingHour = MasterWorkingHours.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedias.ViewClient(),
            };
            return View(data);
        }
        public IActionResult ContactUs()
        {
            var data = new HomeModel
            {
                ListMasterMenu = MasterMenu.ViewClient().ToList(),
                SystemSetting = SystemSetting.ViewClient().SingleOrDefault(),
                ListMasterContactUsInformation = MasterContactUsInformations.ViewClient(),
                ListMasterWorkingHour = MasterWorkingHours.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedias.ViewClient(),
                ListMasterCategoryMenu = MasterCategoryMenus.ViewClient(),
            };
            return View(data);
        }



        public IActionResult Menu()
        {

            var data = new HomeModel
            {
                ListMasterMenu = MasterMenu.ViewClient().ToList(),
                SystemSetting = SystemSetting.ViewClient().SingleOrDefault(),
                ListMasterContactUsInformation = MasterContactUsInformations.ViewClient(),
                ListMasterWorkingHour = MasterWorkingHours.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedias.ViewClient(),
                ListMasterPartner = MasterPartners.ViewClient(),
                ListMasterCategoryMenu = MasterCategoryMenus.ViewClient(),
                ListMasterItemMenu = MasterItemMenu.ViewClient(),

            };
            return View(data);

        }
        public IActionResult ProductDetails(int Id)
        {

            var data = new HomeModel
            {
                ListMasterMenu = MasterMenu.ViewClient().ToList(),
                MasterItemMenu = MasterItemMenu.Find(Id),
                SystemSetting = SystemSetting.ViewClient().SingleOrDefault(),
                ListMasterContactUsInformation = MasterContactUsInformations.ViewClient(),
                ListMasterWorkingHour = MasterWorkingHours.ViewClient(),
                ListMasterSocialMedia = MasterSocialMedias.ViewClient(),
                ListMasterItemMenu = MasterItemMenu.ViewClient(),
            };
            return View(data);

        }


        [HttpPost]
        public IActionResult AddNewsEmail(HomeModel entity)
        {

            TransactionNewsletter.Add(entity.TransactionNewsletter);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult BookTable(HomeModel entity)
        {

            TransactionBookTables.Add(entity.TransactionBookTable);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult ContactUs(HomeModel entity)
        {

            TransactionContactUss.Add(entity.TransactionContactUs);
            return RedirectToAction(nameof(ContactUs));
        }


    }
}
