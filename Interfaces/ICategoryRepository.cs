using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetById(int categoryId);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool IfCategoryExists(int categoryId);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}
