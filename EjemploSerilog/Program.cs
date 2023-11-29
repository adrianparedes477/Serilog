using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Configuracion de Serilog
Log.Logger = new LoggerConfiguration()
    // Ajusta el nivel mínimo de log para la categoría "Microsoft" a "Warning"
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    // Enriquece los eventos de log utilizando el contexto de log
    .Enrich.FromLogContext()
    // Escribe eventos de log en la consola
    .WriteTo.Console()
    // Escribe eventos de log en un archivo llamado "log.txt", con rollover diario
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    // Crea el logger
    .CreateLogger();


//Inicio del servicio
builder.Logging.AddSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
