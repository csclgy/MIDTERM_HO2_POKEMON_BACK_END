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
            {
                new PokemonDto
                {
                    // ImageUrl = "",
                    Name = "Mew",
                    Height = 4.0f,
                    Weight = 40.0f,
                    Type = "Psycho"
                };
            };
        }

        public static List<PokemonDto> GetAllPokemons()
        {
            return PokemonList;
        }

        public static void AddPokemon(PokemonDto dto)
        {
            PokemonList.Add(dto);
        }
    }
}
