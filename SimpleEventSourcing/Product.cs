using SimpleEventSourcing.Events;

namespace SimpleEventSourcing;

internal class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";

    public List<string> Tags { get; set; } = [];

    public void Apply(ProductEvent productEvent)
    {
        switch (productEvent)
        {
            case ProductCreated productCreated:
                Apply(productCreated);
                break;
            case ProductUpdated productUpdated:
                Apply(productUpdated);
                break;
            case ProductTagged productTagged:
                Apply(productTagged);
                break;
            case ProductUnTagged productUnTagged:
                Apply(productUnTagged);
                break;
            default:
                throw new Exception("Unknown event type");
        }
    }

    private void Apply(ProductCreated productCreated)
    {
        Id = productCreated.ProductId;
        Name = productCreated.Name;
    }

    private void Apply(ProductUpdated productUpdated)
    {
        Name = productUpdated.Name;
    }

    private void Apply(ProductTagged productTagged)
    {
        if (!Tags.Contains(productTagged.TagName))
        {
            Tags.Add(productTagged.TagName);
        }
    }

    private void Apply(ProductUnTagged productUnTagged)
    {
        if (Tags.Contains(productUnTagged.TagName))
        {
            Tags.Remove(productUnTagged.TagName);
        }
    }
}


