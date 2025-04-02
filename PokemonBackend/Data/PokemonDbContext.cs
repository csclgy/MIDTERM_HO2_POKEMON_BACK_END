using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Microsoft.Extensions.Configuration;
using PokemonBackend.Models;

namespace PokemonBackend.Data
{
    public class PokemonDbContext
    {
        private readonly string _connectionString;

        public PokemonDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AccessDB");
        }

        public List<Pokemon> GetAllPokemon()
        {
            var pokemons = new List<Pokemon>();

            using (var connection = new OleDbConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Pokemon";
                using (var command = new OleDbCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pokemons.Add(new Pokemon
                        {
                            Id = reader.GetInt32(0),
                            Pokemon_Name = reader.GetString(1),
                            Pokemon_Image = reader.GetString(2),
                            Element_Type = reader.GetString(3),
                            Pokemon_Height = reader.GetInt32(4),
                            Pokemon_Weight = reader.GetInt32(5),
                            Generation = reader.GetInt32(6)
                        });
                    }
                }
            }

            return pokemons;
        }
    }
}
