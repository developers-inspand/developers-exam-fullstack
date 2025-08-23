using System.Reflection;
using Application.Usecases.Books.DeleteBook;
using Application.Usecases.Books.GetAllBooks;
using Application.Usecases.Books.GetBook;
using Application.Usecases.Books.RegisterBook;
using Domain.Entities.Books;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SQLConnection"), b => b.MigrationsAssembly(typeof(SqlDbContext).Assembly.FullName)));

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IRepository<Book>, BookRepository>();

        services.AddScoped<RegisterBookUseCase>();
        services.AddScoped<GetBookById>();
        services.AddScoped<GetAllBooksUseCase>();
        services.AddScoped<DeleteBookUseCase>();

        services.AddScoped<IDomainEventHandler, DomainEventHandler>();

        services.AddScoped<SqlDbContext>();

        return services;
    }
}