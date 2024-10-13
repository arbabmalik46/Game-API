namespace GameAPI.DTOs;

public record class CreateGameDTO(
    int Id,
    string name,
    string Genre,
    decimal price,
    DateOnly ReleaseDate
);
