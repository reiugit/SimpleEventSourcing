namespace SimpleEventSourcing.Events;

internal class ProductUnTagged : ProductEvent
{
    public required string TagName { get; init; }
}
