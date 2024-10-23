using System;
using Microsoft.EntityFrameworkCore;

namespace GameAPI;

public class GameStoreContext(DbContextOptions<GameStoreContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();
}
