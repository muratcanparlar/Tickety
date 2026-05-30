using Tickety.Modules.Events.Application.Events.CreateEvent;
using Tickety.Modules.Events.Infrastructure;
using Tickety.Modules.Events.Presentation.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Ensure controllers from the Presentation project are discovered by MVC
// by registering its assembly as an application part.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(EventsController).Assembly);

// Register Events Module infrastructure (DbContext, repositories, etc.) inside the module boundary
builder.Services.AddEventsInfrastructure(builder.Configuration);

// Register MediatR handlers from the Application assembly
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateEventCommand).Assembly));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
