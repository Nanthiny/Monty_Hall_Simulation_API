using MontyHall.Service.Interfaces;
using MontyHall.Service.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy",
		builderCors => builderCors.WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>())
						.AllowCredentials()
						.AllowAnyHeader()
						.SetIsOriginAllowed(_ => true)
						.AllowAnyMethod()
			);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMontySimulationRepo, MontySimulationRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
