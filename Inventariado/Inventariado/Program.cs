using Inventariado.DAO;
using Inventariado.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

// Agregamos Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregamos la inyección de dependencias para el servicio de bitácora
builder.Services.AddSingleton<IBitacoraService, BitacoraService>();

// Agregamos las inyecciones de los dao
builder.Services.AddSingleton<ProductsDao>();

// Agregamos CORS para permitir solicitudes desde el frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Colocamos que vamos a usar CORS con la política que definimos anteriormente
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
