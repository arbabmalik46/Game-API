using System;

namespace GameAPI;

public static class GamesEndPoints
{
    const string getGameEndPointName = "GetGame";
    private readonly static List<GameDTO> gameDTOs = [

        new GameDTO(ID: 1, Name: "Assassin's Creed Valhalla", Genre:"Adventure",Price: 59.99M,new DateOnly(2010,5,22)),
        new GameDTO(ID: 2, Name: "Need For Speed: Most Wanted", Genre:"Adventure",Price: 119.99M,new DateOnly(2012,10,05)),
        new GameDTO(ID: 3, Name: "GTA V", Genre:"Action",Price: 34.99M,new DateOnly(2013,7,06)),
        new GameDTO(ID: 4, Name: "Final Fantasy XIV", Genre:"Roleplaying",Price: 60.00M,new DateOnly(2010,9,30)),
        new GameDTO(ID: 5, Name: "The Sims 4", Genre:"Simulation",Price: 49.99M,new DateOnly(2016,08,12)),
        new GameDTO(ID: 6, Name: "FIFA 23", Genre:"Sports",Price: 69.99M,new DateOnly(2022,9,27)),
        new GameDTO(ID: 7, Name: "Street Fighter II", Genre:"FIghting",Price: 19.99M,new DateOnly(1992,7,15))
    ];
    public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
    {
        var groups = app.MapGroup("games")
                        .WithParameterValidation();
        //Get Games 
        groups.MapGet("/",()=>gameDTOs);

        //Get game with ID
        groups.MapGet("/{id}",(int id) => {
            GameDTO? game = gameDTOs.Find(game=>game.ID == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
            })
            .WithName(getGameEndPointName);;

        groups.MapPost("/",(CreateGameDTO newDTO)=>{
            GameDTO gameDTO = new (
                gameDTOs.Count+1,
                newDTO.name,
                newDTO.Genre,
                newDTO.price,
                newDTO.ReleaseDate
            );
            gameDTOs.Add(gameDTO);
            return Results.CreatedAtRoute(getGameEndPointName,new {id = gameDTO.ID},gameDTO);
        });

        groups.MapPut("/{id}",(int id,UpdateGameDTO newGameDto) => {
            var index = gameDTOs.FindIndex(gameDto=>gameDto.ID == id);
            if(index == -1)
            {
                return Results.NotFound();
            }

            gameDTOs[index] = new GameDTO(
                id,
                newGameDto.name,
                newGameDto.Genre,
                newGameDto.price,
                newGameDto.ReleaseDate 
            );
            return Results.NoContent();
        });

        groups.MapDelete("/{id}",(int id)=>{
            gameDTOs.RemoveAll(x=>x.ID == id);
            return Results.NoContent();
        });
        return groups;
    }
}
