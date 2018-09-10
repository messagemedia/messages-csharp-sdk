namespace MessageMedia.Messages.Models
{
    public enum MessageStatus
    {
        enroute,
        submitted,
        delivered,
        expired,
        rejected,
        undeliverable,
        queued,
        processed,
        cancelled,
        scheduled,
        failed
    }
}