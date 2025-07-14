using Domain.Events;

namespace Domain.Entities.Books.Events;

public class BookCreatedEvent : DomainEvent
{
    public string Title { get; private set; }

    public BookCreatedEvent(string title)
    {
        Title = title;
    }
}
