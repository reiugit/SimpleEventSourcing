using SimpleEventSourcing;
using SimpleEventSourcing.Events;


var productDatabase = new ProductDatabase();
var productId = Guid.Parse("c48666b2-bc30-43c2-a023-62165829e45c");

var productCreated = new ProductCreated { ProductId = productId, Name = "Test-Product" };
var productUpdated = new ProductUpdated { ProductId = productId, Name = "Updated Test-Product" };
var productTagged1 = new ProductTagged { ProductId = productId, TagName = "Test-Tag 1" };
var productTagged2 = new ProductTagged { ProductId = productId, TagName = "Test-Tag 2" };

productDatabase.Append(productCreated); // create event stream
productDatabase.Append(productTagged1);
productDatabase.Append(productUpdated);
productDatabase.Append(productTagged2);

var productFromView = productDatabase.GetProductFromView(productId)!;     // materialize product from view
var productFromStream = productDatabase.GetProductFromStream(productId)!; // materialize product from event stream

Console.WriteLine();
Console.WriteLine($"Product '{productFromView.Name}' has {productFromView.Tags.Count} Tags.  (from view)");
Console.WriteLine($"Product '{productFromStream.Name}' has {productFromStream.Tags.Count} Tags.  (from stream)");


Console.WriteLine("\n\nPress any key to exit.");
Console.ReadKey(true);
