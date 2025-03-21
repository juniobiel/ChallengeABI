namespace WS.Server.Viewmodels
{
    public class MessageContent
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string Sender { get; set; }
        public Guid ClientId { get; set; }
    }
}
