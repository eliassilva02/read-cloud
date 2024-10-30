namespace Domain.Entities;

public class Book
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Author { get; private set; }
    public string Genre { get; private set; }
    public double Price { get; private set; }
    public DateTime PublicationDate { get; private set; }
    public int StockQuantity { get; private set; }
    public Guid? CollectionId { get; private set; }
}
