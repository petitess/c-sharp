using PokenomReviewApp.Models;

namespace PokenomReviewApp.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();

        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int id);
        bool PokemonExists(int PokemonId);
        bool CreatePokemon (int ownerId, int category, Pokemon pokemon);
        bool UpdatePokemon(int ownerId, int category, Pokemon pokemon);
        bool DeletePokemon(int ownerId, int category, Pokemon pokemon);
        bool Save();

    }
}
