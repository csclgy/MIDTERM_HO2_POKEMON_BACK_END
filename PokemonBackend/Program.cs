using PokemonBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add controller services
builder.Services.AddControllers();

// ✅ Optional: Enable Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Enable CORS (if your frontend needs access)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// ✅ Register the PokemonDbContext as a Singleton (important for MS Access)
builder.Services.AddSingleton<PokemonDbContext>();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

// ✅ Enable API controllers
app.MapControllers();

// ✅ Enable Swagger UI (optional)
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
