namespace SimpleEventSourcing.Events;

internal class ProductCreated : ProductEvent
{
    public required string Name { get; init; }
}
