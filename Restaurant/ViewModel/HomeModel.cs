using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class HomeModel
    {
        public List<MasterMenu> ListMasterMenu { get; set; }


        public List<MasterSlider> ListMasterSlider { get; set; }

        public SystemSetting SystemSetting { get; set; }
        public MasterOffer MasterOffers { get; set; }
        public TransactionNewsletter TransactionNewsletter { get; set; }
        public TransactionContactU TransactionContactUs { get; set; }
        public TransactionBookTable TransactionBookTable { get; set; }
        public List<MasterService> ListMasterService { get; set; }

        public List<MasterCategoryMenu> ListMasterCategoryMenu { get; set; }
        public List<MasterItemMenu> ListMasterItemMenu { get; set; }

        public MasterItemMenu MasterItemMenu { get; set; }


        public List<FeedBack> ListFeedBack { get; set; }

        public List<MasterContactUsInformation> ListMasterContactUsInformation { get; set; }

        public List<MasterPartner> ListMasterPartner { get; set; }
        public List<MasterSocialMedium> ListMasterSocialMedia { get; set; }
        public List<MasterWorkingHour> ListMasterWorkingHour { get; set; }

    }
}
