using System.ComponentModel;
using GameAPI;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connectionString);
var app = builder.Build();
app.MapGamesEndPoints();
app.MigrateDB();
app.Run();
