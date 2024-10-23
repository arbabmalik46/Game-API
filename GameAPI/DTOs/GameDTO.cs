using System.ComponentModel.DataAnnotations;

namespace GameAPI;

public record class GameDTO(int ID, [Required][StringLength(50)]string Name, [Required][StringLength(50)]string Genre, [Required]decimal Price,[Required]DateOnly ReleaseDate);
