using DataContext;
using Entities;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Requests.Appointments;
using Services.GenericRepository;
using Services.GenericService;
using Services.Hubs;
using Services.Validators;

var builder = WebApplication.CreateBuilder(args);

// Configurar el DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar inyección de dependencias para el repositorio genérico
builder.Services.AddScoped<ISvGenericRepository<Appointment>, SvGenericRepository<Appointment, MyDbContext>>();

// Configurar MediatR para manejar los comandos y consultas
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAppointmentHandler).Assembly));

// Configurar SignalR
builder.Services.AddSignalR();

// Configurar FluentValidation
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<DTOAppointmentValidator>();
        fv.ImplicitlyValidateChildProperties = true;
    })
    .AddNewtonsoftJson(x =>
        x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Configurar Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS para permitir solicitudes desde el frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policyBuilder => policyBuilder
            .WithOrigins("http://localhost:5173") // Especifica el origen de tu frontend
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

// Configurar middleware de manejo de errores
app.UseMiddleware<ErrorHandlingMiddleware>();

// Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurar CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Mapear el Hub de SignalR
app.MapHub<NotificationHub>("/notificationHub");

app.Run();
