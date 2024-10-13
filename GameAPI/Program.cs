using System.ComponentModel;
using GameAPI.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
const string getGameEndPointName = "GetGame";

List<GameDTO> gameDTOs = [

    new GameDTO(ID: 1, Name: "Assassin's Creed Valhalla", Genre:"Adventure",Price: 59.99M,new DateOnly(2010,5,22)),
    new GameDTO(ID: 2, Name: "Need For Speed: Most Wanted", Genre:"Adventure",Price: 119.99M,new DateOnly(2012,10,05)),
    new GameDTO(ID: 3, Name: "GTA V", Genre:"Action",Price: 34.99M,new DateOnly(2013,7,06)),
    new GameDTO(ID: 4, Name: "Final Fantasy XIV", Genre:"Roleplaying",Price: 60.00M,new DateOnly(2010,9,30)),
    new GameDTO(ID: 5, Name: "The Sims 4", Genre:"Simulation",Price: 49.99M,new DateOnly(2016,08,12)),
    new GameDTO(ID: 6, Name: "FIFA 23", Genre:"Sports",Price: 69.99M,new DateOnly(2022,9,27)),
    new GameDTO(ID: 7, Name: "Street Fighter II", Genre:"FIghting",Price: 19.99M,new DateOnly(1992,7,15))
];

//Get Games 
app.MapGet("games",()=>gameDTOs);

//Get game with ID
app.MapGet("games/{id}",(int id)=>gameDTOs.Find(game=>game.ID == id)).WithName(getGameEndPointName);;

app.MapPost("games",(CreateGameDTO newDTO)=>{
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

app.MapPut("games/{id}",(int id,UpdateGameDTO newGameDto) => {
    var index = gameDTOs.FindIndex(gameDto=>gameDto.ID == id);
    gameDTOs[index] = new GameDTO(
        id,
        newGameDto.name,
        newGameDto.Genre,
        newGameDto.price,
        newGameDto.ReleaseDate 
    );
    return Results.NoContent();
});
app.Run();
