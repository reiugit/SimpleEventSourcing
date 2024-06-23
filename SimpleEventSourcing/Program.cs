using SimpleEventSourcing;
using SimpleEventSourcing.Events;


var productDatabase = new ProductDatabase();
var productId = Guid.Parse("c48666b2-bc30-43c2-a023-62165829e45c");

var productCreated = new ProductCreated { ProductId = productId, Name = "Test-Product" };
var productUpdated = new ProductUpdated { ProductId = productId, Name = "Updated Test-Product" };
var productTagged1 = new ProductTagged { ProductId = productId, TagName = "Test-Tag 1" };
var productTagged2 = new ProductTagged { ProductId = productId, TagName = "Test-Tag 2" };

productDatabase.Append(productCreated); // Create Event Stream
productDatabase.Append(productTagged1);
productDatabase.Append(productUpdated);
productDatabase.Append(productTagged2);

var productFromView = productDatabase.GetProductFromView(productId)!;     // Materialize Product from View
var productFromStream = productDatabase.GetProductFromStream(productId)!; // Materialize Product from Event Stream

Console.WriteLine();
Console.WriteLine($"Product '{productFromView.Name}' has {productFromView.Tags.Count} Tags.");
Console.WriteLine($"Product '{productFromStream.Name}' has {productFromStream.Tags.Count} Tags.");


