using System;


namespace API.Models.Entities
{
    public class Subscription
    {
        public string SubscriberId { get; set; }
        public User Subscriber { get; set; }
        public string ChanelAuthorId { get; set; }
        public User ChanelAuthor { get; set; }
        public DateTime DateOfCreateSubscription { get; set; }

    }
}
