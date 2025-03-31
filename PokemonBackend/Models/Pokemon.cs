using System.ComponentModel.DataAnnotations;

namespace PokemonBackend.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        [Required]
        public string Pokemon_Name { get; set; } = string.Empty; // Default to empty string

        [Required]
        public string Pokemon_Image { get; set; } = string.Empty;

        [Required]
        public string Element_Type { get; set; } = string.Empty;

        public float Pokemon_Height { get; set; }
        public float Pokemon_Weight { get; set; }
    }
}