namespace SimpleEventSourcing.Events;

internal class ProductUpdated : ProductEvent
{
    public required string Name { get; init; }
}
