using Project.Models;

namespace Project.Services;

public static class FavoriteService
{
    public static void SaveToFavorites(Favourite favourite, int userId)
    {
        using var context = new ContextMovie();
        context.Favourites.Add(favourite);
        context.SaveChanges();
    }

    public static List<Favourite> GetFavorites()
    {
        using var context = new ContextMovie();
        return context.Favourites.ToList();
    }

    public static void DisplayAllFavourites()
    {
        using var context = new ContextMovie();
        var favourites = context.Favourites.ToList();
        foreach (var fav in favourites)
        {
            Console.WriteLine(fav);
        }
    }
}