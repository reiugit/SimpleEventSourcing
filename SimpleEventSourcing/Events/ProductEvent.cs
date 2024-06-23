namespace SimpleEventSourcing.Events;

internal abstract class ProductEvent()
{
    public required Guid ProductId { get; init; }
    public DateTime CreatedAtUtc { get; set; }

}
