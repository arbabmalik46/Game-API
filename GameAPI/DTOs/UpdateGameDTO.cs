namespace GameAPI;

public record class UpdateGameDTO(
    int Id,
    string name,
    string Genre,
    decimal price,
    DateOnly ReleaseDate
);
