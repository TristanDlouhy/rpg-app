using RpgApi.Data;
using RpgApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add db context
builder.Services.AddDbContext<DataContext>();

// Add services to the container.
builder.Services.AddScoped<ICharacterService, CharacterService>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
