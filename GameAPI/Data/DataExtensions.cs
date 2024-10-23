using System;
using Microsoft.EntityFrameworkCore;

namespace GameAPI;

public static class DataExtensions
{
    public static void MigrateDB(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<GameStoreContext>();
        dbContext.Database.Migrate();
    }
}
