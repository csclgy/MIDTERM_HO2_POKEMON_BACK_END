namespace PokemonBackend.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Pokemon_Name { get; set; }
        public string Pokemon_Image { get; set; }
        public string Element_Type { get; set; }
        public float Pokemon_Height { get; set; }
        public float Pokemon_Weight { get; set; }
        public int Generation { get; set; }
    }
}
