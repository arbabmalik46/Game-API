using System;

namespace GameAPI;

public class Game
{
    public int Id { get; set; }
    public required string name { get; set; }
    public int GenreID { get; set; }

    public Genre? Genre { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDate {get; set;}
    
}
