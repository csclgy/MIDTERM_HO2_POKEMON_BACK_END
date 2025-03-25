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
            PokemonList = new List<PokemonDto>
            {
                new PokemonDto
                {
                    ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/151.png",
                    Name = "Mew",
                    Height = 4.0f,
                    Weight = 40.0f,
                    Type = "Psycho"
                },
                
                new PokemonDto
                {
                    ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png",
                    Name = "Pikachu",
                    Height = 4.0f,
                    Weight = 60.0f,
                    Type = "Electric"
                },

                new PokemonDto
                {
                    ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png",
                    Name = "Bulbasaur",
                    Height = 7.0f,
                    Weight = 69.0f,
                    Type = "Grass/Poison"
                },
                new PokemonDto
                {
                    ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png",
                    Name = "Charmander",
                    Height = 6.0f,
                    Weight = 85.0f,
                    Type = "Fire"
                },
                new PokemonDto
                {
                    ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/7.png",
                    Name = "Squirtle",
                    Height = 5.0f,
                    Weight = 90.0f,
                    Type = "Water"
                },
                new PokemonDto
                {
                    ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/39.png",
                    Name = "Jigglypuff",
                    Height = 5.0f,
                    Weight = 55.0f,
                    Type = "Normal/Fairy"
                },
                new PokemonDto
                {
                    ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/52.png",
                    Name = "Meowth",
                    Height = 4.0f,
                    Weight = 42.0f,
                    Type = "Normal"
                },
                new PokemonDto
                {
                    ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/95.png",
                    Name = "Onix",
                    Height = 88.0f,
                    Weight = 2100.0f,
                    Type = "Rock/Ground"
                },
                new PokemonDto
                {
                    ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/131.png",
                    Name = "Lapras",
                    Height = 25.0f,
                    Weight = 2200.0f,
                    Type = "Water/Ice"
                },
                new PokemonDto
                {
                    ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/143.png",
                    Name = "Snorlax",
                    Height = 21.0f,
                    Weight = 4600.0f,
                    Type = "Normal"
                },
                new PokemonDto
                {
                    ImageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/150.png",
                    Name = "Mewtwo",
                    Height = 20.0f,
                    Weight = 1220.0f,
                    Type = "Psychic"
                }

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
