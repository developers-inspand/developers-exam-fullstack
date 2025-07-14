using Domain.Entities.Books.Events;
using Domain.Events;
using Domain.Interfaces;

namespace Application.Usecases.Books.RegisterBook;

public class RegisterBookEventHandler : IDomainEventHandler
{
    private readonly IEmailService emailService;

    public RegisterBookEventHandler(IEmailService emailService)
    {
        this.emailService = emailService;
    }

    public async Task Publish(DomainEvent domainEvent)
    {
        if (domainEvent is BookCreatedEvent bookCreatedEvent)
        {
            emailService.SendEmail("developers@inspand.com.br", $"New Book Registered: {bookCreatedEvent.Title}");
        }
        await Task.CompletedTask;
    }
}
