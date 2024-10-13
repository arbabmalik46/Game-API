namespace GameAPI.DTOs;

public record class UpdateGameDTO(
    int Id,
    string name,
    string Genre,
    decimal price,
    DateOnly ReleaseDate
);
