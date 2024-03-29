using TCGTracker.API.Context;
using TCGTracker.API.DAL;
using TCGTracker.API.DAL.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DapperContext>();
//builder.Services.AddTransient<IMockData, MockData>();
builder.Services.AddTransient<IPlayerDAL, PlayerDAL>();
builder.Services.AddTransient<IDeckDAL, DeckDAL>();
builder.Services.AddTransient<IMatchDAL, MatchDAL>();

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
