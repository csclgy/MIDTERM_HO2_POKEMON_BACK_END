namespace PokemonBackend
{
    public class PokemonDto
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public string? Type { get; set; }
    }

    public static class PokemonRepository
    {
        private static readonly List<PokemonDto> PokemonList;

        static PokemonRepository()
        {
            PokemonList = new List<PokemonDto>();
        }
    }
}
