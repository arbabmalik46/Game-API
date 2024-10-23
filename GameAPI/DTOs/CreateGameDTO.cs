using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GameAPI;

public record class CreateGameDTO(
    int Id,
    [Required]
    [StringLength(50)]
    string name,
    string Genre,
    [Required]
    decimal price,
    DateOnly ReleaseDate
);
