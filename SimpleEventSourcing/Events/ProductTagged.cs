namespace SimpleEventSourcing.Events;

internal class ProductTagged : ProductEvent
{
    public required string TagName { get; init; }
}
