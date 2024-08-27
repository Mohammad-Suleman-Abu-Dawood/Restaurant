namespace Restaurant.Models
{
    public class FeedBack:BaseEntity
    {
        public int FeedBackId { get; set; }
        public string FeedBackMessage { get; set; }

        public string FeedBackImgUrl { get; set; }

        public string FeedBackName { get; set; }

        public string FeedBackRole { get; set; }
    }
}
