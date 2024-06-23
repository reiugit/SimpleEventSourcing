using SimpleEventSourcing.Events;

namespace SimpleEventSourcing;

internal class ProductDatabase
{
    private readonly Dictionary<Guid, List<ProductEvent>> _productEventStreams = []; // Event Streams
    private readonly Dictionary<Guid, Product> _products = [];                 // Views

    internal void Append(ProductEvent @event)
    {
        if (!_productEventStreams.TryGetValue(@event.ProductId, out var eventStream))
        {
            eventStream = _productEventStreams[@event.ProductId] = [];
        }

        @event.CreatedAtUtc = DateTime.UtcNow;

        eventStream.Add(@event); // Append to Stream

        Update_View(@event);
    }

    public Product? GetProductFromView(Guid productId)
    {
        return _products.GetValueOrDefault(productId);
    }

    internal Product? GetProductFromStream(Guid productId)
    {
        if (!_productEventStreams.TryGetValue(productId, out var EventStream))
        {
            return null;
        }

        var product = new Product();

        foreach (var @event in EventStream)
        {
            product.Apply(@event);
        }

        return product;
    }

    private void Update_View(ProductEvent @event)
    {
        if (!_products.TryGetValue(@event.ProductId, out var product))
        {
            product = _products[@event.ProductId] = new();
        }

        product.Apply(@event);
    }

}
